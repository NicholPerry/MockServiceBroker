using EasyModbus;
using ModbusMockService.Models;
using ModbusMockService.Models.Signals;
using System.Net;
using static EasyModbus.ModbusServer;

namespace ModbusMockService
{
    public partial class MockService : Form
    {
        private readonly ModbusServer _server;
        private readonly HoldingRegisters _registers;
        private readonly Dictionary<string, List<Signal>> _signalDictionary = SignalDictionary.GetSignalGroups();
        private TaskCompletionSource<bool> _robotArrived = new();
        private string _robotNextTargetArea = "SafetyArea";
        private int _palletCount = 0;
        private bool machineInterfaceEnabled = false;

        public MockService()
        {
            InitializeComponent();

            // Server
            _server = new ModbusServer();
            // Update to IP running the service - disable LocalIPAddress and Port to enable machine interface
            _server.LocalIPAddress = IPAddress.Parse("10.1.50.22");
           _server.Port = 502;
            _server.Listen();

            _registers = _server.holdingRegisters;
            InitializeHoldingRegisters();
            _server.HoldingRegistersChanged += Server_HoldingRegistersChanged;
            InitializeSystemStartUp();
        }

        private void InitializeHoldingRegisters()
        {
            foreach (var signalGroup in _signalDictionary)
            {
                LogOutput($"Initializing {signalGroup.Key}...");
                foreach (var signal in _signalDictionary[signalGroup.Key])
                {
                    // Initialize holding registers based on signal type
                    switch (signal)
                    {
                        case BoolSignal boolSignal:
                            SetBit(_registers[boolSignal.RegisterAddress], boolSignal.Bit, boolSignal.CurrentValue);
                            if (signalGroup.Key == "MachineSignals")
                            {
                                UpdateMachineSignalStatus(boolSignal.SignalName);
                            }
                            break;

                        case ByteSignal byteSignal:
                            _registers[byteSignal.RegisterAddress] = byteSignal.CurrentValue;
                            break;
                        default:
                            break;
                    }
                }
            }
            LogOutput("----------------------------------------------------------------------------------------");
        }

        private void InitializeSystemStartUp()
        {
            lblStatus.Text = "Status: Running";
            machineInterfaceEnabled = _server.LocalIPAddress.ToString() == "0.0.0.0";

            if (machineInterfaceEnabled)
            {
                InitializeLifeBit();
                EnableMachineControls();
                UpdateMachineButtonText();
            }

            LogOutput("Waiting for unload pallet request from machine...");
            SetNextUserInteraction(btnUnloadPalletRequest);
            btnRobotInStop.BackColor = Color.Green;
            btnRobotInOperatorArea.BackColor = Color.Green;
        }

        private void InitializeLifeBit()
        {
            SetMachineSignal(SignalName.LifeBit);
            UpdateButtonText(btnSimulateLifeBitChange);
        }

        private void EnableMachineControls()
        {
            btnSimulateLifeBitChange.Visible = true;
            btnUnloadPalletRequest.Enabled = true;
            btnLoadPalletRequest.Enabled = true;
            btnGrantOperatorAreaAccess.Enabled = true;
            btnGrantSafetyAreaAccess.Enabled = true;
            btnGrantBendingAreaAccess.Enabled = true;
        }

        private void UpdateMachineButtonText()
        {
            UpdateButtonText(btnGrantOperatorAreaAccess);
            UpdateButtonText(btnGrantSafetyAreaAccess);
            UpdateButtonText(btnGrantBendingAreaAccess);
        }

        private void SetBit(int registerAddress, int bitPosition, bool value)
        {
            // Read the current value of the register
            int currentValue = _registers[registerAddress];

            // Set or clear the bit based on the value
            if (value)
            {
                // Set the bit at 'bitPosition':
                // - (1 << bitPosition) creates a bitmask with only the bit at 'bitPosition' set to 1.
                // - The |= operator sets that bit in 'currentValue' to 1, without affecting other bits.
                currentValue |= (1 << bitPosition);
            }
            else
            {
                // Clear the bit at 'bitPosition':
                // - (1 << bitPosition) creates a bitmask with only the bit at 'bitPosition' set to 1.
                // - ~(1 << bitPosition) flips the bits so that the bit at 'bitPosition' becomes 0, and all other bits become 1.
                // - The &= operator clears that bit (sets it to 0), while leaving all other bits unchanged.
                currentValue &= ~(1 << bitPosition);
            }

            // Write the updated value back to the register
            _registers[registerAddress] = (short)currentValue;
        }

        private void Server_HoldingRegistersChanged(int registerIndex, int numberOfRegisters)
        {
            // Read the current value of the register at the specified index
            int currentValue = _registers[registerIndex];

            var machineSignalsAtRegister = _signalDictionary["MachineSignals"]
                .Where(s => s.RegisterAddress == registerIndex)
                .OfType<BoolSignal>()
                .ToList();

            Signal changedSignal = null!;

            foreach (var signal in machineSignalsAtRegister)
            {
                // Check the bit in the current value of the register
                bool newBitValue = (currentValue & (1 << signal.Bit)) != 0;

                // Compare with the current value of the signal
                if (signal.CurrentValue != newBitValue)
                {
                    signal.CurrentValue = newBitValue;
                    changedSignal = signal;

                    if (!machineInterfaceEnabled)
                    {
                        UpdateMachineSignalStatus(signal.SignalName);
                        LogOutput($"Machine set {signal.SignalName} to {signal.CurrentValue}.");
                        LogOutput("----------------------------------------------------------------------------------------");
                    }
                }
            }

            if (changedSignal != null)
            {
                switch (changedSignal.SignalName)
                {
                    case SignalName.UnloadPalletRequest:
                        ReceiveUnloadPalletRequest();
                        break;
                    case SignalName.LoadPalletRequest:
                        ReceiveLoadPalletRequest();
                        break;
                    case SignalName.PermissionToEnterSafetyAreaAllowed:
                        ReceiveSafetyAreaPermission();
                        break;
                    case SignalName.PermissionToEnterBendingAreaAllowed:
                        ReceiveBendingAreaPermission();
                        break;
                    case SignalName.PermissionToEnterOperatorAreaAllowed:
                        ReceiveOperatorAreaPermission();
                        break;
                    case SignalName.LifeBit:
                        UpdateLifeBitStatus();
                        break;
                    default:
                        break;
                }
            }
        }

        #region ServiceMethods
        private void ReceiveUnloadPalletRequest()
        {
            if (GetSignalValue(SignalName.UnloadPalletRequest, "MachineSignals"))
            {
                // Set the AllUnloadPalletDone register to false
                SetServiceSignal(SignalName.AllUnloadPalletDone, false, btnUnloadPalletDone);

                // Set the PermissionToEnterSafetyAreaRequest register to true
                SetServiceSignal(SignalName.PermissionToEnterSafetyAreaRequest, true, btnRequestSafetyAreaPermission);

                // Hightlight next UI interaction
                SetNextUserInteraction(btnGrantSafetyAreaAccess);
                SetWaitingForMachineAccess("safety area");
            }
            else
            {
                SetNextUserInteraction(btnLoadPalletRequest);
            }
        }

        private void ReceiveLoadPalletRequest()
        {
            if (GetSignalValue(SignalName.LoadPalletRequest, "MachineSignals"))
            {
                // Set the AllLoadPalletDone register to false
                SetServiceSignal(SignalName.AllLoadPalletDone, false, btnLoadPalletDone);

                // Set the PermissionToEnterSafetyAreaRequest register to true
                SetServiceSignal(SignalName.PermissionToEnterSafetyAreaRequest, true, btnRequestSafetyAreaPermission);

                // Highlight next UI interaction
                SetNextUserInteraction(btnGrantSafetyAreaAccess);
                SetWaitingForMachineAccess("safety area");
            }
            else
            {
                SetNextUserInteraction(btnUnloadPalletRequest);
            }
        }

        private async void ReceiveOperatorAreaPermission()
        {
            switch (_robotNextTargetArea)
            {
                case "SafetyArea":
                    // Set the PermissionToEnterOperatorAreaRequest register to false
                    SetServiceSignal(SignalName.PermissionToEnterOperatorAreaRequest, false, btnRequestOperatorAreaPermission);

                    string missionArea = "operator";
                    // Send MIR on mission
                    SendRobotOnMission(missionArea);
                    SetNextUserInteraction(btnRobotArrived);

                    await _robotArrived.Task;
                    ResetButtonColor(btnRobotEnroute);
                    RobotArrivedInArea(missionArea);

                    // Set robot in safety area
                    SetServiceSignal(SignalName.RobotInSafetyArea, false, btnRobotInSafetyArea);

                    // Set robot in operator area
                    SetServiceSignal(SignalName.RobotInOperatorArea, true, btnRobotInOperatorArea);

                    bool unloadRequest = GetSignalValue(SignalName.UnloadPalletRequest, "MachineSignals");
                    bool loadRequest = GetSignalValue(SignalName.LoadPalletRequest, "MachineSignals");
                    if (unloadRequest || loadRequest)
                    {
                        var action = unloadRequest ? "Unloading" : "Loading";

                        LogOutput($"{action} pallet {_palletCount + 1} in operator area...");
                    }

                    _robotArrived = new TaskCompletionSource<bool>();

                    if (_palletCount == 0)
                    {
                        _robotNextTargetArea = "GetNextPallet";
                        _palletCount++;
                        SetNextUserInteraction(btnGrantOperatorAreaAccess);
                    }
                    else
                    {
                        SetServiceSignal(SignalName.AllUnloadPalletDone, true, btnUnloadPalletDone);
                        _robotNextTargetArea = "UnloadDone";
                        SetNextUserInteraction(btnGrantOperatorAreaAccess);
                    }
                    break;
                case "GetNextPallet":
                    // Request safety area access
                    SetServiceSignal(SignalName.PermissionToEnterSafetyAreaRequest, true, btnRequestSafetyAreaPermission);
                    _robotNextTargetArea = "SafetyArea";
                    SetNextUserInteraction(btnGrantSafetyAreaAccess);
                    break;
                case "UnloadDone":
                    LogOutput("Waiting for next request from machine...");
                    _robotNextTargetArea = "SafetyArea";
                    if (GetSignalValue(SignalName.UnloadPalletRequest, "MachineSignals"))
                    {
                        btnUnloadPalletDone.BackColor = Color.Green;
                        SetNextUserInteraction(btnUnloadPalletRequest);
                    }

                    if (GetSignalValue(SignalName.LoadPalletRequest, "MachineSignals"))
                    {
                        btnLoadPalletDone.BackColor = Color.Green;
                        SetNextUserInteraction(btnLoadPalletRequest);
                    }
                    _palletCount = 0;

                    break;
                default:
                    break;
            }
        }


        private async void ReceiveBendingAreaPermission()
        {
            switch (_robotNextTargetArea)
            {
                case "SafetyArea":
                    LogOutput("Waiting for pallet to unload...");
                    // Set the PermissionToEnterSafetyAreaRequest register to true
                    SetServiceSignal(SignalName.PermissionToEnterSafetyAreaRequest, true, btnRequestSafetyAreaPermission);
                    SetNextUserInteraction(btnGrantSafetyAreaAccess);
                    SetWaitingForMachineAccess("safety area");
                    _robotNextTargetArea = "OperatorArea";
                    break;
                case "BendingArea":
                    // Set the PermissionToEnterBendingAreaRequest register to false
                    SetServiceSignal(SignalName.PermissionToEnterBendingAreaRequest, false, btnRequestBendingAreaPermission);
                    string missionArea = "bending";
                    // Send MIR on mission
                    SendRobotOnMission(missionArea);
                    SetNextUserInteraction(btnRobotArrived);

                    // Wait for MIR to get to next point
                    await _robotArrived.Task;
                    ResetButtonColor(btnRobotEnroute);
                    RobotArrivedInArea(missionArea);

                    // Set robot in bending area
                    SetServiceSignal(SignalName.RobotInSafetyArea, false, btnRobotInSafetyArea);
                    SetServiceSignal(SignalName.MirInBendingArea, true, btnRobotInBendingArea);

                    _robotNextTargetArea = "SafetyArea";
                    _robotArrived = new TaskCompletionSource<bool>();

                    SetNextUserInteraction(btnGrantBendingAreaAccess);
                    break;
                default:
                    break;
            }
        }

        private async void ReceiveSafetyAreaPermission()
        {
            string missionArea = "safety";

            switch (_robotNextTargetArea)
            {
                case "SafetyArea":
                    // Set the PermissionToEnterSafetyAreaRequest register to false
                    SetServiceSignal(SignalName.PermissionToEnterSafetyAreaRequest, false, btnRequestSafetyAreaPermission);

                    // Send mission to MIR
                    SendRobotOnMission(missionArea);
                    SetNextUserInteraction(btnRobotArrived);

                    // Wait for MIR to get to next point
                    await _robotArrived.Task;
                    ResetButtonColor(btnRobotEnroute);
                    RobotArrivedInArea(missionArea);

                    // Set robot in safety area
                    SetServiceSignal(SignalName.RobotInOperatorArea, false, btnRobotInOperatorArea);
                    SetServiceSignal(SignalName.RobotInSafetyArea, true, btnRobotInSafetyArea);

                    _robotNextTargetArea = "BendingArea";
                    SetNextUserInteraction(btnGrantSafetyAreaAccess);
                    _robotArrived = new TaskCompletionSource<bool>();
                    break;
                case "BendingArea":
                    // Set the PermissionToEnterBendingAreaRequest register to true
                    SetServiceSignal(SignalName.PermissionToEnterBendingAreaRequest, true, btnRequestBendingAreaPermission);
                    SetNextUserInteraction(btnGrantBendingAreaAccess);
                    SetWaitingForMachineAccess("bending area");
                    break;
                case "OperatorArea":
                    // Set the PermissionToEnterSafetyAreaRequest register to false
                    SetServiceSignal(SignalName.PermissionToEnterSafetyAreaRequest, false, btnRequestSafetyAreaPermission);

                    // Send mission to MIR
                    SendRobotOnMission(missionArea);
                    SetNextUserInteraction(btnRobotArrived);

                    // Wait for MIR to get to next point
                    await _robotArrived.Task;
                    ResetButtonColor(btnRobotEnroute);
                    RobotArrivedInArea(missionArea);

                    // Set robot in safety area
                    SetServiceSignal(SignalName.MirInBendingArea, false, btnRobotInBendingArea);
                    SetServiceSignal(SignalName.RobotInSafetyArea, true, btnRobotInSafetyArea);

                    _robotArrived = new TaskCompletionSource<bool>();
                    _robotNextTargetArea = "EnterOperatorArea";
                    SetNextUserInteraction(btnGrantSafetyAreaAccess);
                    break;
                case "EnterOperatorArea":
                    //Set the PermissionToEnterOperatorAreaRequest register to true
                    SetServiceSignal(SignalName.PermissionToEnterOperatorAreaRequest, true, btnRequestOperatorAreaPermission);
                    SetNextUserInteraction(btnGrantOperatorAreaAccess);
                    SetWaitingForMachineAccess("operator area");
                    _robotNextTargetArea = "SafetyArea";
                    break;
                default:
                    break;
            }
        }

        private void UpdateLifeBitStatus()
        {
            BoolSignal signal = (BoolSignal)_signalDictionary["MachineSignals"].First(s => s.SignalName == SignalName.LifeBit);
            btnLifeBitStatus.BackColor = signal.CurrentValue ? Color.Green : Color.Red;

            UpdateButtonText(btnSimulateLifeBitChange);
            UpdateUserControls(signal.CurrentValue);

            if (!signal.CurrentValue)
            {
                MessageBox.Show($"Machine is stopped; perform system reset.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region MachineControls
        private void btnUnloadPalletRequest_Click(object sender, EventArgs e)
        {
            ResetButtonColor(btnUnloadPalletRequest);
            UpdateButtonText(btnUnloadPalletRequest);
            SetMachineSignal(SignalName.UnloadPalletRequest);
        }

        private void btnLoadPalletRequest_Click(object sender, EventArgs e)
        {
            ResetButtonColor(btnLoadPalletRequest);
            UpdateButtonText(btnLoadPalletRequest);
            SetMachineSignal(SignalName.LoadPalletRequest);
        }

        private void btnGrantOperatorAreaAccess_Click(object sender, EventArgs e)
        {
            ResetButtonColor(btnGrantOperatorAreaAccess);
            UpdateButtonText(btnGrantOperatorAreaAccess);
            SetMachineSignal(SignalName.PermissionToEnterOperatorAreaAllowed);
        }

        private void btnGrantSafetyAreaAccess_Click(object sender, EventArgs e)
        {
            ResetButtonColor(btnGrantSafetyAreaAccess);
            UpdateButtonText(btnGrantSafetyAreaAccess);
            SetMachineSignal(SignalName.PermissionToEnterSafetyAreaAllowed);
        }

        private void btnGrantBendingAreaAccess_Click(object sender, EventArgs e)
        {
            ResetButtonColor(btnGrantBendingAreaAccess);
            UpdateButtonText(btnGrantBendingAreaAccess);
            SetMachineSignal(SignalName.PermissionToEnterBendingAreaAllowed);
        }

        private void btnSimulateLifeBitChange_Click(object sender, EventArgs e)
        {
            SetMachineSignal(SignalName.LifeBit);
        }
        #endregion

        #region RobotControls
        private void btnRobotArrived_Click(object sender, EventArgs e)
        {
            ResetButtonColor(btnRobotArrived);
            _robotArrived.SetResult(true);
        }
        #endregion
        private void SetWaitingForMachineAccess(string accessName)
        {
            LogOutput($"Waiting for {accessName} access from machine...");
            LogOutput("----------------------------------------------------------------------------------------");
        }

        private static void UpdateButtonText(Button button)
        {
            if (button.InvokeRequired)
            {
                button.Invoke(new Action(() => UpdateButtonText(button)));
            }
            else
            {
                switch (button.Text)
                {
                    case "Unload Pallet Request":
                        button.Text = "Executing Unload Sequence";
                        break;
                    case "Executing Unload Sequence":
                        button.Text = "Unload Pallet Request";
                        break;
                    case "Load Pallet Request":
                        button.Text = "Executing Load Sequence";
                        break;
                    case "Executing Load Sequence":
                        button.Text = "Load Pallet Request";
                        break;
                    case "Grant Safety Area Access":
                        button.Text = "Revoke Safety Area Access";
                        break;
                    case "Revoke Safety Area Access":
                    case "Permission To Enter Safety Area Allowed":
                        button.Text = "Grant Safety Area Access";
                        break;
                    case "Grant Bending Area Access":
                        button.Text = "Revoke Bending Area Access";
                        break;
                    case "Revoke Bending Area Access":
                    case "Permission To Enter Bending Area Allowed":
                        button.Text = "Grant Bending Area Access";
                        break;
                    case "Grant Operator Area Access":
                        button.Text = "Revoke Operator Area Access";
                        break;
                    case "Revoke Operator Area Access":
                    case "Permission To Enter Operator Area Allowed":
                        button.Text = "Grant Operator Area Access";
                        break;
                    case "Simulate Life Bit Change":
                        button.Text = "System Reset";
                        break;
                    case "System Reset":
                        button.Text = "Simulate Life Bit Change";
                        break;
                    default:
                        break;
                }
            }
        }

        private bool GetSignalValue(SignalName signalName, string signalGroup)
        {
            BoolSignal signal = (BoolSignal)_signalDictionary[signalGroup].First(s => s.SignalName == signalName);

            return signal.CurrentValue;

        }

        private void UpdateUserControls(bool value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUserControls(value)));
            }
            else
            {
                btnUnloadPalletRequest.Enabled = value;
                btnLoadPalletRequest.Enabled = value;
                btnGrantOperatorAreaAccess.Enabled = value;
                btnGrantSafetyAreaAccess.Enabled = value;
                btnGrantBendingAreaAccess.Enabled = value;
                btnRobotArrived.Enabled = value;
                btnRobotEnroute.Enabled = value;
                btnRobotInStop.Enabled = value;
            }
        }

        private void RobotArrivedInArea(string missionArea)
        {
            LogOutput($"MIR arrived in {missionArea} area...");
            BoolSignal robotStoppedInOperatorArea = (BoolSignal)_signalDictionary["ServiceSignals"].First(s => s.SignalName == SignalName.RobotInStop);
            SetBit(robotStoppedInOperatorArea.RegisterAddress, robotStoppedInOperatorArea.Bit, true);
            btnRobotInStop.BackColor = Color.Green;
        }

        private void SendRobotOnMission(string missionArea)
        {
            LogOutput($"MIR enroute to {missionArea} area...");
            btnRobotEnroute.BackColor = Color.Green;

            SetServiceSignal(SignalName.RobotInStop, false, btnRobotInStop);

            LogOutput("Waiting for MIR to arrive...");
            LogOutput("----------------------------------------------------------------------------------------");
        }

        private void SetServiceSignal(SignalName signalName, bool value, Button button)
        {
            BoolSignal signal = (BoolSignal)_signalDictionary["ServiceSignals"].First(s => s.SignalName == signalName);
            SetBit(signal.RegisterAddress, signal.Bit, value);

            LogOutput($"Service set {signalName} to {value}.");

            button.BackColor = value ? Color.Green : Color.Red;
        }

        private void UpdateMachineSignalStatus(SignalName signalName)
        {
            BoolSignal signal = (BoolSignal)_signalDictionary["MachineSignals"].First(s => s.SignalName == signalName);

            var buttonMap = new Dictionary<SignalName, Button>
            {
                { SignalName.UnloadPalletRequest, btnUnloadPalletRequest },
                { SignalName.LoadPalletRequest, btnLoadPalletRequest },
                { SignalName.PermissionToEnterOperatorAreaAllowed, btnGrantOperatorAreaAccess },
                { SignalName.PermissionToEnterSafetyAreaAllowed, btnGrantSafetyAreaAccess },
                { SignalName.PermissionToEnterBendingAreaAllowed, btnGrantBendingAreaAccess }
            };

            if (buttonMap.TryGetValue(signalName, out var button))
            {
                button.BackColor = signal.CurrentValue ? Color.Green : Color.Red;
            }
        }

        private void SetMachineSignal(SignalName signalName)
        {
            BoolSignal signal = (BoolSignal)_signalDictionary["MachineSignals"].First(s => s.SignalName == signalName);
            SetBit(signal.RegisterAddress, signal.Bit, !signal.CurrentValue);
            LogOutput($"Machine set {signal.SignalName} to {!signal.CurrentValue}.");
            LogOutput("----------------------------------------------------------------------------------------");

            // Manually trigger the event
            Server_HoldingRegistersChanged(signal.RegisterAddress, 1);
        }

        private void SetNextUserInteraction(Button button)
        {
            if (machineInterfaceEnabled || button == btnRobotArrived)
            {
                button.BackColor = Color.HotPink;
            }
        }

        private static void ResetButtonColor(Button button)
        {
            button.BackColor = SystemColors.Control;
        }

        private void LogOutput(string message)
        {
            if (txtOutput.InvokeRequired)
            {
                // If we're not on the UI thread, marshal the call to the UI thread
                txtOutput.Invoke(new Action(() => LogOutput(message)));
            }
            else
            {
                // We're on the UI thread, safe to update the control directly
                txtOutput.AppendText(message + Environment.NewLine);
            }
        }
    }
}
