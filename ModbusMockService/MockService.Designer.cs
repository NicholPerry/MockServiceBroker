
namespace ModbusMockService
{
    partial class MockService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            btnSimulateLifeBitChange = new Button();
            btnLifeBitStatus = new Button();
            lblStatus = new Label();
            splitContainer3 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            lblMachineControls = new Label();
            btnLoadPalletRequest = new Button();
            btnUnloadPalletRequest = new Button();
            btnGrantBendingAreaAccess = new Button();
            btnGrantSafetyAreaAccess = new Button();
            btnGrantOperatorAreaAccess = new Button();
            splitContainer5 = new SplitContainer();
            lblServiceControls = new Label();
            btnLoadPalletDone = new Button();
            btnUnloadPalletDone = new Button();
            splitContainer6 = new SplitContainer();
            btnRobotInBendingArea = new Button();
            btnRobotInSafetyArea = new Button();
            btnRobotInOperatorArea = new Button();
            btnRequestBendingAreaPermission = new Button();
            btnRequestSafetyAreaPermission = new Button();
            btnRequestOperatorAreaPermission = new Button();
            splitContainer7 = new SplitContainer();
            btnRobotInStop = new Button();
            btnRobotEnroute = new Button();
            btnRobotArrived = new Button();
            lblRobotControls = new Label();
            txtOutput = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
            splitContainer6.Panel1.SuspendLayout();
            splitContainer6.Panel2.SuspendLayout();
            splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer7).BeginInit();
            splitContainer7.Panel1.SuspendLayout();
            splitContainer7.Panel2.SuspendLayout();
            splitContainer7.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4, 5, 4, 5);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer7);
            splitContainer1.Size = new Size(1262, 1256);
            splitContainer1.SplitterDistance = 368;
            splitContainer1.SplitterWidth = 7;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(4, 5, 4, 5);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(btnSimulateLifeBitChange);
            splitContainer2.Panel1.Controls.Add(btnLifeBitStatus);
            splitContainer2.Panel1.Controls.Add(lblStatus);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(1262, 368);
            splitContainer2.SplitterDistance = 71;
            splitContainer2.SplitterWidth = 7;
            splitContainer2.TabIndex = 0;
            // 
            // btnSimulateLifeBitChange
            // 
            btnSimulateLifeBitChange.Location = new Point(774, 12);
            btnSimulateLifeBitChange.Name = "btnSimulateLifeBitChange";
            btnSimulateLifeBitChange.Size = new Size(235, 34);
            btnSimulateLifeBitChange.TabIndex = 2;
            btnSimulateLifeBitChange.Text = "Simulate Life Bit Change";
            btnSimulateLifeBitChange.UseVisualStyleBackColor = true;
            btnSimulateLifeBitChange.Visible = false;
            btnSimulateLifeBitChange.Click += btnSimulateLifeBitChange_Click;
            // 
            // btnLifeBitStatus
            // 
            btnLifeBitStatus.Enabled = false;
            btnLifeBitStatus.Location = new Point(1024, 12);
            btnLifeBitStatus.Name = "btnLifeBitStatus";
            btnLifeBitStatus.Size = new Size(182, 34);
            btnLifeBitStatus.TabIndex = 1;
            btnLifeBitStatus.Text = "Life Bit Status";
            btnLifeBitStatus.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(31, 15);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(137, 25);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status: Stopped";
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Margin = new Padding(4, 5, 4, 5);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer5);
            splitContainer3.Size = new Size(1262, 290);
            splitContainer3.SplitterDistance = 561;
            splitContainer3.SplitterWidth = 6;
            splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Margin = new Padding(4, 5, 4, 5);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(lblMachineControls);
            splitContainer4.Panel1.Controls.Add(btnLoadPalletRequest);
            splitContainer4.Panel1.Controls.Add(btnUnloadPalletRequest);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(btnGrantBendingAreaAccess);
            splitContainer4.Panel2.Controls.Add(btnGrantSafetyAreaAccess);
            splitContainer4.Panel2.Controls.Add(btnGrantOperatorAreaAccess);
            splitContainer4.Size = new Size(561, 290);
            splitContainer4.SplitterDistance = 90;
            splitContainer4.SplitterWidth = 7;
            splitContainer4.TabIndex = 0;
            // 
            // lblMachineControls
            // 
            lblMachineControls.AutoSize = true;
            lblMachineControls.Location = new Point(193, 0);
            lblMachineControls.Margin = new Padding(4, 0, 4, 0);
            lblMachineControls.Name = "lblMachineControls";
            lblMachineControls.Size = new Size(150, 25);
            lblMachineControls.TabIndex = 2;
            lblMachineControls.Text = "Machine Controls";
            // 
            // btnLoadPalletRequest
            // 
            btnLoadPalletRequest.Enabled = false;
            btnLoadPalletRequest.Location = new Point(278, 29);
            btnLoadPalletRequest.Margin = new Padding(4, 5, 4, 5);
            btnLoadPalletRequest.Name = "btnLoadPalletRequest";
            btnLoadPalletRequest.Size = new Size(199, 38);
            btnLoadPalletRequest.TabIndex = 1;
            btnLoadPalletRequest.Text = "Load Pallet Request";
            btnLoadPalletRequest.UseVisualStyleBackColor = true;
            btnLoadPalletRequest.Click += btnLoadPalletRequest_Click;
            // 
            // btnUnloadPalletRequest
            // 
            btnUnloadPalletRequest.Enabled = false;
            btnUnloadPalletRequest.Location = new Point(53, 29);
            btnUnloadPalletRequest.Margin = new Padding(4, 5, 4, 5);
            btnUnloadPalletRequest.Name = "btnUnloadPalletRequest";
            btnUnloadPalletRequest.Size = new Size(199, 38);
            btnUnloadPalletRequest.TabIndex = 0;
            btnUnloadPalletRequest.Text = "Unload Pallet Request";
            btnUnloadPalletRequest.UseVisualStyleBackColor = true;
            btnUnloadPalletRequest.Click += btnUnloadPalletRequest_Click;
            // 
            // btnGrantBendingAreaAccess
            // 
            btnGrantBendingAreaAccess.Enabled = false;
            btnGrantBendingAreaAccess.Location = new Point(73, 117);
            btnGrantBendingAreaAccess.Margin = new Padding(4, 5, 4, 5);
            btnGrantBendingAreaAccess.Name = "btnGrantBendingAreaAccess";
            btnGrantBendingAreaAccess.Size = new Size(404, 38);
            btnGrantBendingAreaAccess.TabIndex = 2;
            btnGrantBendingAreaAccess.Text = "Permission To Enter Bending Area Allowed";
            btnGrantBendingAreaAccess.UseVisualStyleBackColor = true;
            btnGrantBendingAreaAccess.Click += btnGrantBendingAreaAccess_Click;
            // 
            // btnGrantSafetyAreaAccess
            // 
            btnGrantSafetyAreaAccess.Enabled = false;
            btnGrantSafetyAreaAccess.Location = new Point(73, 68);
            btnGrantSafetyAreaAccess.Margin = new Padding(4, 5, 4, 5);
            btnGrantSafetyAreaAccess.Name = "btnGrantSafetyAreaAccess";
            btnGrantSafetyAreaAccess.Size = new Size(404, 38);
            btnGrantSafetyAreaAccess.TabIndex = 1;
            btnGrantSafetyAreaAccess.Text = "Permission To Enter Safety Area Allowed";
            btnGrantSafetyAreaAccess.UseVisualStyleBackColor = true;
            btnGrantSafetyAreaAccess.Click += btnGrantSafetyAreaAccess_Click;
            // 
            // btnGrantOperatorAreaAccess
            // 
            btnGrantOperatorAreaAccess.Enabled = false;
            btnGrantOperatorAreaAccess.Location = new Point(73, 20);
            btnGrantOperatorAreaAccess.Margin = new Padding(4, 5, 4, 5);
            btnGrantOperatorAreaAccess.Name = "btnGrantOperatorAreaAccess";
            btnGrantOperatorAreaAccess.Size = new Size(404, 38);
            btnGrantOperatorAreaAccess.TabIndex = 0;
            btnGrantOperatorAreaAccess.Text = "Permission To Enter Operator Area Allowed";
            btnGrantOperatorAreaAccess.UseVisualStyleBackColor = true;
            btnGrantOperatorAreaAccess.Click += btnGrantOperatorAreaAccess_Click;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Margin = new Padding(4, 5, 4, 5);
            splitContainer5.Name = "splitContainer5";
            splitContainer5.Orientation = Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(lblServiceControls);
            splitContainer5.Panel1.Controls.Add(btnLoadPalletDone);
            splitContainer5.Panel1.Controls.Add(btnUnloadPalletDone);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(splitContainer6);
            splitContainer5.Size = new Size(695, 290);
            splitContainer5.SplitterDistance = 88;
            splitContainer5.SplitterWidth = 7;
            splitContainer5.TabIndex = 0;
            // 
            // lblServiceControls
            // 
            lblServiceControls.AutoSize = true;
            lblServiceControls.Location = new Point(197, 0);
            lblServiceControls.Margin = new Padding(4, 0, 4, 0);
            lblServiceControls.Name = "lblServiceControls";
            lblServiceControls.Size = new Size(139, 25);
            lblServiceControls.TabIndex = 3;
            lblServiceControls.Text = "Service Controls";
            // 
            // btnLoadPalletDone
            // 
            btnLoadPalletDone.Enabled = false;
            btnLoadPalletDone.Location = new Point(316, 27);
            btnLoadPalletDone.Margin = new Padding(4, 5, 4, 5);
            btnLoadPalletDone.Name = "btnLoadPalletDone";
            btnLoadPalletDone.Size = new Size(213, 38);
            btnLoadPalletDone.TabIndex = 2;
            btnLoadPalletDone.Text = "Load Pallet Done";
            btnLoadPalletDone.UseVisualStyleBackColor = true;
            // 
            // btnUnloadPalletDone
            // 
            btnUnloadPalletDone.Enabled = false;
            btnUnloadPalletDone.Location = new Point(56, 27);
            btnUnloadPalletDone.Margin = new Padding(4, 5, 4, 5);
            btnUnloadPalletDone.Name = "btnUnloadPalletDone";
            btnUnloadPalletDone.Size = new Size(213, 38);
            btnUnloadPalletDone.TabIndex = 1;
            btnUnloadPalletDone.Text = "Unload Pallet Done";
            btnUnloadPalletDone.UseVisualStyleBackColor = true;
            // 
            // splitContainer6
            // 
            splitContainer6.Dock = DockStyle.Fill;
            splitContainer6.Location = new Point(0, 0);
            splitContainer6.Margin = new Padding(4, 5, 4, 5);
            splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            splitContainer6.Panel1.Controls.Add(btnRobotInBendingArea);
            splitContainer6.Panel1.Controls.Add(btnRobotInSafetyArea);
            splitContainer6.Panel1.Controls.Add(btnRobotInOperatorArea);
            // 
            // splitContainer6.Panel2
            // 
            splitContainer6.Panel2.Controls.Add(btnRequestBendingAreaPermission);
            splitContainer6.Panel2.Controls.Add(btnRequestSafetyAreaPermission);
            splitContainer6.Panel2.Controls.Add(btnRequestOperatorAreaPermission);
            splitContainer6.Size = new Size(695, 195);
            splitContainer6.SplitterDistance = 297;
            splitContainer6.SplitterWidth = 6;
            splitContainer6.TabIndex = 0;
            // 
            // btnRobotInBendingArea
            // 
            btnRobotInBendingArea.Enabled = false;
            btnRobotInBendingArea.Location = new Point(40, 119);
            btnRobotInBendingArea.Margin = new Padding(4, 5, 4, 5);
            btnRobotInBendingArea.Name = "btnRobotInBendingArea";
            btnRobotInBendingArea.Size = new Size(213, 38);
            btnRobotInBendingArea.TabIndex = 2;
            btnRobotInBendingArea.Text = "Robot In Bending Area";
            btnRobotInBendingArea.UseVisualStyleBackColor = true;
            // 
            // btnRobotInSafetyArea
            // 
            btnRobotInSafetyArea.Enabled = false;
            btnRobotInSafetyArea.Location = new Point(40, 71);
            btnRobotInSafetyArea.Margin = new Padding(4, 5, 4, 5);
            btnRobotInSafetyArea.Name = "btnRobotInSafetyArea";
            btnRobotInSafetyArea.Size = new Size(213, 38);
            btnRobotInSafetyArea.TabIndex = 1;
            btnRobotInSafetyArea.Text = "Robot In Safety Area";
            btnRobotInSafetyArea.UseVisualStyleBackColor = true;
            // 
            // btnRobotInOperatorArea
            // 
            btnRobotInOperatorArea.Enabled = false;
            btnRobotInOperatorArea.Location = new Point(40, 22);
            btnRobotInOperatorArea.Margin = new Padding(4, 5, 4, 5);
            btnRobotInOperatorArea.Name = "btnRobotInOperatorArea";
            btnRobotInOperatorArea.Size = new Size(213, 38);
            btnRobotInOperatorArea.TabIndex = 0;
            btnRobotInOperatorArea.Text = "Robot In Operator Area";
            btnRobotInOperatorArea.UseVisualStyleBackColor = true;
            // 
            // btnRequestBendingAreaPermission
            // 
            btnRequestBendingAreaPermission.Enabled = false;
            btnRequestBendingAreaPermission.Location = new Point(65, 119);
            btnRequestBendingAreaPermission.Margin = new Padding(4, 5, 4, 5);
            btnRequestBendingAreaPermission.Name = "btnRequestBendingAreaPermission";
            btnRequestBendingAreaPermission.Size = new Size(290, 38);
            btnRequestBendingAreaPermission.TabIndex = 2;
            btnRequestBendingAreaPermission.Text = "Request Bending Area Permission";
            btnRequestBendingAreaPermission.UseVisualStyleBackColor = true;
            // 
            // btnRequestSafetyAreaPermission
            // 
            btnRequestSafetyAreaPermission.Enabled = false;
            btnRequestSafetyAreaPermission.Location = new Point(65, 71);
            btnRequestSafetyAreaPermission.Margin = new Padding(4, 5, 4, 5);
            btnRequestSafetyAreaPermission.Name = "btnRequestSafetyAreaPermission";
            btnRequestSafetyAreaPermission.Size = new Size(290, 38);
            btnRequestSafetyAreaPermission.TabIndex = 1;
            btnRequestSafetyAreaPermission.Text = "Request Safety Area Permission";
            btnRequestSafetyAreaPermission.UseVisualStyleBackColor = true;
            // 
            // btnRequestOperatorAreaPermission
            // 
            btnRequestOperatorAreaPermission.Enabled = false;
            btnRequestOperatorAreaPermission.Location = new Point(65, 22);
            btnRequestOperatorAreaPermission.Margin = new Padding(4, 5, 4, 5);
            btnRequestOperatorAreaPermission.Name = "btnRequestOperatorAreaPermission";
            btnRequestOperatorAreaPermission.Size = new Size(290, 38);
            btnRequestOperatorAreaPermission.TabIndex = 0;
            btnRequestOperatorAreaPermission.Text = "Request Operator Area Permission";
            btnRequestOperatorAreaPermission.UseVisualStyleBackColor = true;
            // 
            // splitContainer7
            // 
            splitContainer7.Dock = DockStyle.Fill;
            splitContainer7.Location = new Point(0, 0);
            splitContainer7.Margin = new Padding(4, 5, 4, 5);
            splitContainer7.Name = "splitContainer7";
            splitContainer7.Orientation = Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            splitContainer7.Panel1.Controls.Add(btnRobotInStop);
            splitContainer7.Panel1.Controls.Add(btnRobotEnroute);
            splitContainer7.Panel1.Controls.Add(btnRobotArrived);
            splitContainer7.Panel1.Controls.Add(lblRobotControls);
            // 
            // splitContainer7.Panel2
            // 
            splitContainer7.Panel2.Controls.Add(txtOutput);
            splitContainer7.Size = new Size(1262, 881);
            splitContainer7.SplitterDistance = 109;
            splitContainer7.SplitterWidth = 7;
            splitContainer7.TabIndex = 0;
            // 
            // btnRobotInStop
            // 
            btnRobotInStop.Location = new Point(807, 47);
            btnRobotInStop.Margin = new Padding(4, 5, 4, 5);
            btnRobotInStop.Name = "btnRobotInStop";
            btnRobotInStop.Size = new Size(320, 38);
            btnRobotInStop.TabIndex = 3;
            btnRobotInStop.Text = "Robot In Stop";
            btnRobotInStop.UseVisualStyleBackColor = true;
            // 
            // btnRobotEnroute
            // 
            btnRobotEnroute.Location = new Point(478, 47);
            btnRobotEnroute.Margin = new Padding(4, 5, 4, 5);
            btnRobotEnroute.Name = "btnRobotEnroute";
            btnRobotEnroute.Size = new Size(320, 38);
            btnRobotEnroute.TabIndex = 2;
            btnRobotEnroute.Text = "Enroute";
            btnRobotEnroute.UseVisualStyleBackColor = true;
            // 
            // btnRobotArrived
            // 
            btnRobotArrived.Location = new Point(149, 47);
            btnRobotArrived.Margin = new Padding(4, 5, 4, 5);
            btnRobotArrived.Name = "btnRobotArrived";
            btnRobotArrived.Size = new Size(320, 38);
            btnRobotArrived.TabIndex = 1;
            btnRobotArrived.Text = "Arrived";
            btnRobotArrived.UseVisualStyleBackColor = true;
            btnRobotArrived.Click += btnRobotArrived_Click;
            // 
            // lblRobotControls
            // 
            lblRobotControls.AutoSize = true;
            lblRobotControls.Location = new Point(537, 12);
            lblRobotControls.Margin = new Padding(4, 0, 4, 0);
            lblRobotControls.Name = "lblRobotControls";
            lblRobotControls.Size = new Size(133, 25);
            lblRobotControls.TabIndex = 0;
            lblRobotControls.Text = "Robot Controls";
            // 
            // txtOutput
            // 
            txtOutput.BackColor = SystemColors.ScrollBar;
            txtOutput.Location = new Point(0, -5);
            txtOutput.Margin = new Padding(4, 5, 4, 5);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(1258, 764);
            txtOutput.TabIndex = 0;
            // 
            // MockService
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1262, 1256);
            Controls.Add(splitContainer1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MockService";
            Text = "MockService";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel1.PerformLayout();
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel1.PerformLayout();
            splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            splitContainer6.Panel1.ResumeLayout(false);
            splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
            splitContainer6.ResumeLayout(false);
            splitContainer7.Panel1.ResumeLayout(false);
            splitContainer7.Panel1.PerformLayout();
            splitContainer7.Panel2.ResumeLayout(false);
            splitContainer7.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer7).EndInit();
            splitContainer7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer5;
        private SplitContainer splitContainer6;
        private Button btnLoadPalletRequest;
        private Button btnUnloadPalletRequest;
        private Button btnLoadPalletDone;
        private Button btnUnloadPalletDone;
        private SplitContainer splitContainer7;
        private Label lblMachineControls;
        private Label lblServiceControls;
        private Button btnRobotArrived;
        private Label lblRobotControls;
        private Button btnRobotInStop;
        private Button btnRobotEnroute;
        private Button btnGrantBendingAreaAccess;
        private Button btnGrantSafetyAreaAccess;
        private Button btnGrantOperatorAreaAccess;
        private Button btnRobotInBendingArea;
        private Button btnRobotInSafetyArea;
        private Button btnRobotInOperatorArea;
        private Button btnRequestBendingAreaPermission;
        private Button btnRequestSafetyAreaPermission;
        private Button btnRequestOperatorAreaPermission;
        private TextBox txtOutput;
        private Label lblStatus;
        private Button btnSimulateLifeBitChange;
        private Button btnLifeBitStatus;
    }
}