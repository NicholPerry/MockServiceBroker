using ModbusMockService.Models.Signals;

namespace ModbusMockService.Models
{
    public static class SignalDictionary
    {
        public static Dictionary<string, List<Signal>> GetSignalGroups()
        {
            var machineSignals = new List<Signal>()
            {
                // Word 6 = Register 48
                new BoolSignal(SignalName.LifeBit, 6, 0, 0, "PWM with periode=500ms and duty=50%"),
                new BoolSignal(SignalName.UnloadPalletRequest, 6, 0, 1, "Unload all pallets request from bender"),
                new BoolSignal(SignalName.LoadPalletRequest, 6, 0, 2, "Load all pallets request from bender"),
                new BoolSignal(SignalName.PermissionToEnterSafetyAreaAllowed, 6, 0, 3, "Permission to enter in safety area"),
                new BoolSignal(SignalName.PermissionToEnterBendingAreaAllowed, 6, 0, 4, "Permission to enter in bending area"),
                new BoolSignal(SignalName.PermissionToEnterOperatorAreaAllowed, 6, 0, 5, "Permission to enter in operator area"),
                new BoolSignal(SignalName.Spare, 6, 0, 6, "Spare"),
                new BoolSignal(SignalName.Spare, 6, 0, 7, "Spare"),
                new BoolSignal(SignalName.Spare, 6, 1, 0, "Spare"),
                new BoolSignal(SignalName.Spare, 6, 1, 1, "Spare"),
                new BoolSignal(SignalName.Spare, 6, 1, 2, "Spare"),
                new BoolSignal(SignalName.Spare, 6, 1, 3, "Spare"),
                new BoolSignal(SignalName.Spare, 6, 1, 4, "Spare"),
                new BoolSignal(SignalName.Spare, 6, 1, 5, "Spare"),
                new BoolSignal(SignalName.Spare, 6, 1, 6, "Spare"),
                new BoolSignal(SignalName.BenderInAlarm, 6, 1, 7, "Bender in alarm"),
                new BoolSignal(SignalName.Spare, 7, 2, 0, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 2, 2, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 2, 3, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 2, 4, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 2, 5, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 2, 6, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 2, 7, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 3, 0, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 3, 1, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 3, 2, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 3, 3, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 3, 4, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 3, 5, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 3, 6, "Spare"),
                new BoolSignal(SignalName.Spare, 7, 3, 7, "Spare"),
                new ByteSignal(SignalName.LayoutID, 2, 4, "Actual Layout ID"),
                new ByteSignal(SignalName.Spare, 8, 5, "Spare"),
                new ByteSignal(SignalName.Spare, 9, 6, "Spare"),
                new ByteSignal(SignalName.Spare, 9, 7, "Spare"),
                new ByteSignal(SignalName.Spare, 10, 8, "Spare"),
                new ByteSignal(SignalName.Spare, 10, 9, "Spare"),
                new ByteSignal(SignalName.Spare, 11, 10, "Spare"),
                new ByteSignal(SignalName.Spare, 11, 11, "Spare")
            };


            var serviceSignals = new List<Signal>()
            {
                new BoolSignal(SignalName.LifeBit, 0, 0, 0, "PWM with periode=500ms and duty=50%"),
                new BoolSignal(SignalName.AllUnloadPalletDone, 0, 0, 1, "All Pallets are unloaded from stacking area"),
                new BoolSignal(SignalName.AllLoadPalletDone, 0, 0, 2, "All Pallet are loaded to stacking area"),
                new BoolSignal(SignalName.RobotInOperatorArea, 0, 0, 3, "Robot in operator area"),
                new BoolSignal(SignalName.PermissionToEnterOperatorAreaRequest, 0, 0, 4, "Req from robot to enter in operator area"),
                new BoolSignal(SignalName.RobotInSafetyArea, 0, 0, 5, "Robot in  safety area"),
                new BoolSignal(SignalName.PermissionToEnterSafetyAreaRequest, 0, 0, 6, "Req from robot to enter in safety area"),
                new BoolSignal(SignalName.MirInBendingArea, 0, 0, 7, "Robot in Bending area"),
                new BoolSignal(SignalName.PermissionToEnterBendingAreaRequest, 0, 1, 0, "Req from robot to enter in bending area"),
                new BoolSignal(SignalName.RobotInStop, 0, 1, 1, "Robot is stopped"),
                new BoolSignal(SignalName.Spare, 0, 1, 2, "Spare"),
                new BoolSignal(SignalName.Spare, 0, 1, 3, "Spare"),
                new BoolSignal(SignalName.Spare, 0, 1, 4, "Spare"),
                new BoolSignal(SignalName.Spare, 0, 1, 5, "Spare"),
                new BoolSignal(SignalName.Spare, 0, 1, 6, "Spare"),
                new BoolSignal(SignalName.RobotInAlarm, 0, 1, 7, "Robot in alarm"),
                new BoolSignal(SignalName.Spare, 1, 2, 0, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 2, 1, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 2, 2, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 2, 3, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 2, 4, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 2, 5, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 2, 6, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 2, 7, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 3, 0, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 3, 1, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 3, 2, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 3, 3, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 3, 4, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 3, 5, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 3, 6, "Spare"),
                new BoolSignal(SignalName.Spare, 1, 3, 7, "Spare"),
                new ByteSignal(SignalName.RobotAlarmCode, 2, 4, "Alarm code from Robot (for HMI msg)"),
                new ByteSignal(SignalName.Spare, 2, 5, "Spare"),
                new ByteSignal(SignalName.Spare, 3, 6, "Spare"),
                new ByteSignal(SignalName.Spare, 3, 7, "Spare"),
                new ByteSignal(SignalName.Spare, 4, 8, "Spare"),
                new ByteSignal(SignalName.Spare, 4, 9, "Spare"),
                new ByteSignal(SignalName.Spare, 5, 10, "Spare"),
                new ByteSignal(SignalName.Spare, 5, 11, "Spare")
            };

            var signalGroups = new Dictionary<string, List<Signal>>()
            {
                { "MachineSignals", machineSignals },
                { "ServiceSignals", serviceSignals }
            };

            return signalGroups;
        }
    }
}
