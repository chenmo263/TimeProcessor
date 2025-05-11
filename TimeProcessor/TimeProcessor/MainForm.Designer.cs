namespace TimeProcessor
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox groupBoxRange;
        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.GroupBox groupBoxVersion;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblStartCol;
        private System.Windows.Forms.Label lblEndCol;
        private System.Windows.Forms.Label lblStartRow;
        private System.Windows.Forms.Label lblEndRow;
        private System.Windows.Forms.TextBox txtStartCol;
        private System.Windows.Forms.TextBox txtEndCol;
        private System.Windows.Forms.TextBox txtStartRow;
        private System.Windows.Forms.TextBox txtEndRow;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblFileInfo;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.Label lblLatestVersion;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelLeft = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnSettings = new System.Windows.Forms.Button();
            btnAbout = new System.Windows.Forms.Button();
            groupBoxRange = new System.Windows.Forms.GroupBox();
            lblStartCol = new System.Windows.Forms.Label();
            txtStartCol = new System.Windows.Forms.TextBox();
            lblEndCol = new System.Windows.Forms.Label();
            txtEndCol = new System.Windows.Forms.TextBox();
            lblStartRow = new System.Windows.Forms.Label();
            txtStartRow = new System.Windows.Forms.TextBox();
            lblEndRow = new System.Windows.Forms.Label();
            txtEndRow = new System.Windows.Forms.TextBox();
            groupBoxFile = new System.Windows.Forms.GroupBox();
            btnSelectFile = new System.Windows.Forms.Button();
            btnProcess = new System.Windows.Forms.Button();
            lblFileInfo = new System.Windows.Forms.Label();
            groupBoxVersion = new System.Windows.Forms.GroupBox();
            lblCurrentVersion = new System.Windows.Forms.Label();
            lblLatestVersion = new System.Windows.Forms.Label();
            panelRight = new System.Windows.Forms.Panel();
            groupBoxResult = new System.Windows.Forms.GroupBox();
            txtResult = new System.Windows.Forms.TextBox();
            groupBoxLog = new System.Windows.Forms.GroupBox();
            txtLog = new System.Windows.Forms.TextBox();
            btnClearLog = new System.Windows.Forms.Button();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            progressBar = new System.Windows.Forms.ProgressBar();
            panelLeft.SuspendLayout();
            groupBoxRange.SuspendLayout();
            groupBoxFile.SuspendLayout();
            groupBoxVersion.SuspendLayout();
            panelRight.SuspendLayout();
            groupBoxResult.SuspendLayout();
            groupBoxLog.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(lblTitle);
            panelLeft.Controls.Add(btnSettings);
            panelLeft.Controls.Add(btnAbout);
            panelLeft.Controls.Add(groupBoxRange);
            panelLeft.Controls.Add(groupBoxFile);
            panelLeft.Controls.Add(groupBoxVersion);
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new System.Windows.Forms.Padding(10);
            panelLeft.Size = new System.Drawing.Size(320, 660);
            panelLeft.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(145, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "考勤数据处理";
            // 
            // btnSettings
            // 
            btnSettings.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            btnSettings.Location = new System.Drawing.Point(190, 20);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new System.Drawing.Size(60, 23);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "设置";
            // 
            // btnAbout
            // 
            btnAbout.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            btnAbout.Location = new System.Drawing.Point(250, 20);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new System.Drawing.Size(60, 23);
            btnAbout.TabIndex = 2;
            btnAbout.Text = "关于";
            // 
            // groupBoxRange
            // 
            groupBoxRange.Controls.Add(lblStartCol);
            groupBoxRange.Controls.Add(txtStartCol);
            groupBoxRange.Controls.Add(lblEndCol);
            groupBoxRange.Controls.Add(txtEndCol);
            groupBoxRange.Controls.Add(lblStartRow);
            groupBoxRange.Controls.Add(txtStartRow);
            groupBoxRange.Controls.Add(lblEndRow);
            groupBoxRange.Controls.Add(txtEndRow);
            groupBoxRange.Location = new System.Drawing.Point(10, 60);
            groupBoxRange.Name = "groupBoxRange";
            groupBoxRange.Size = new System.Drawing.Size(300, 120);
            groupBoxRange.TabIndex = 3;
            groupBoxRange.TabStop = false;
            groupBoxRange.Text = "数据范围设置";
            // 
            // lblStartCol
            // 
            lblStartCol.AutoSize = true;
            lblStartCol.Location = new System.Drawing.Point(20, 30);
            lblStartCol.Name = "lblStartCol";
            lblStartCol.Size = new System.Drawing.Size(56, 17);
            lblStartCol.TabIndex = 0;
            lblStartCol.Text = "起始列：";
            // 
            // txtStartCol
            // 
            txtStartCol.Location = new System.Drawing.Point(80, 27);
            txtStartCol.Name = "txtStartCol";
            txtStartCol.Size = new System.Drawing.Size(40, 23);
            txtStartCol.TabIndex = 1;
            txtStartCol.Text = "A";
            // 
            // lblEndCol
            // 
            lblEndCol.AutoSize = true;
            lblEndCol.Location = new System.Drawing.Point(140, 30);
            lblEndCol.Name = "lblEndCol";
            lblEndCol.Size = new System.Drawing.Size(56, 17);
            lblEndCol.TabIndex = 2;
            lblEndCol.Text = "结束列：";
            // 
            // txtEndCol
            // 
            txtEndCol.Location = new System.Drawing.Point(200, 27);
            txtEndCol.Name = "txtEndCol";
            txtEndCol.Size = new System.Drawing.Size(40, 23);
            txtEndCol.TabIndex = 3;
            txtEndCol.Text = "AE";
            // 
            // lblStartRow
            // 
            lblStartRow.AutoSize = true;
            lblStartRow.Location = new System.Drawing.Point(20, 70);
            lblStartRow.Name = "lblStartRow";
            lblStartRow.Size = new System.Drawing.Size(56, 17);
            lblStartRow.TabIndex = 4;
            lblStartRow.Text = "起始行：";
            // 
            // txtStartRow
            // 
            txtStartRow.Location = new System.Drawing.Point(80, 67);
            txtStartRow.Name = "txtStartRow";
            txtStartRow.Size = new System.Drawing.Size(40, 23);
            txtStartRow.TabIndex = 5;
            txtStartRow.Text = "16";
            // 
            // lblEndRow
            // 
            lblEndRow.AutoSize = true;
            lblEndRow.Location = new System.Drawing.Point(140, 70);
            lblEndRow.Name = "lblEndRow";
            lblEndRow.Size = new System.Drawing.Size(56, 17);
            lblEndRow.TabIndex = 6;
            lblEndRow.Text = "结束行：";
            // 
            // txtEndRow
            // 
            txtEndRow.Location = new System.Drawing.Point(200, 67);
            txtEndRow.Name = "txtEndRow";
            txtEndRow.Size = new System.Drawing.Size(40, 23);
            txtEndRow.TabIndex = 7;
            txtEndRow.Text = "16";
            // 
            // groupBoxFile
            // 
            groupBoxFile.Controls.Add(btnSelectFile);
            groupBoxFile.Controls.Add(btnProcess);
            groupBoxFile.Controls.Add(lblFileInfo);
            groupBoxFile.Location = new System.Drawing.Point(10, 190);
            groupBoxFile.Name = "groupBoxFile";
            groupBoxFile.Size = new System.Drawing.Size(300, 110);
            groupBoxFile.TabIndex = 4;
            groupBoxFile.TabStop = false;
            groupBoxFile.Text = "文件操作";
            // 
            // btnSelectFile
            // 
            btnSelectFile.BackColor = System.Drawing.Color.LightSkyBlue;
            btnSelectFile.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            btnSelectFile.Location = new System.Drawing.Point(20, 30);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new System.Drawing.Size(120, 23);
            btnSelectFile.TabIndex = 0;
            btnSelectFile.Text = "选择Excel文件";
            btnSelectFile.UseVisualStyleBackColor = false;
            // 
            // btnProcess
            // 
            btnProcess.BackColor = System.Drawing.Color.PaleGreen;
            btnProcess.Enabled = false;
            btnProcess.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            btnProcess.Location = new System.Drawing.Point(160, 30);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new System.Drawing.Size(120, 23);
            btnProcess.TabIndex = 1;
            btnProcess.Text = "处理数据";
            btnProcess.UseVisualStyleBackColor = false;
            // 
            // lblFileInfo
            // 
            lblFileInfo.AutoSize = true;
            lblFileInfo.Location = new System.Drawing.Point(20, 70);
            lblFileInfo.Name = "lblFileInfo";
            lblFileInfo.Size = new System.Drawing.Size(154, 17);
            lblFileInfo.TabIndex = 2;
            lblFileInfo.Text = "请选择要处理的Excel文件...";
            // 
            // groupBoxVersion
            // 
            groupBoxVersion.Controls.Add(lblCurrentVersion);
            groupBoxVersion.Controls.Add(lblLatestVersion);
            groupBoxVersion.Location = new System.Drawing.Point(10, 310);
            groupBoxVersion.Name = "groupBoxVersion";
            groupBoxVersion.Size = new System.Drawing.Size(300, 80);
            groupBoxVersion.TabIndex = 5;
            groupBoxVersion.TabStop = false;
            groupBoxVersion.Text = "版本信息";
            // 
            // lblCurrentVersion
            // 
            lblCurrentVersion.AutoSize = true;
            lblCurrentVersion.Location = new System.Drawing.Point(20, 30);
            lblCurrentVersion.Name = "lblCurrentVersion";
            lblCurrentVersion.Size = new System.Drawing.Size(95, 17);
            lblCurrentVersion.TabIndex = 0;
            lblCurrentVersion.Text = "当前版本：1.0.0";
            // 
            // lblLatestVersion
            // 
            lblLatestVersion.AutoSize = true;
            lblLatestVersion.Location = new System.Drawing.Point(20, 55);
            lblLatestVersion.Name = "lblLatestVersion";
            lblLatestVersion.Size = new System.Drawing.Size(92, 17);
            lblLatestVersion.TabIndex = 1;
            lblLatestVersion.Text = "最新版本：未知";
            // 
            // panelRight
            // 
            panelRight.Controls.Add(groupBoxResult);
            panelRight.Controls.Add(groupBoxLog);
            panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            panelRight.Location = new System.Drawing.Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new System.Windows.Forms.Padding(10);
            panelRight.Size = new System.Drawing.Size(1000, 660);
            panelRight.TabIndex = 1;
            // 
            // groupBoxResult
            // 
            groupBoxResult.Controls.Add(txtResult);
            groupBoxResult.Dock = System.Windows.Forms.DockStyle.Top;
            groupBoxResult.Location = new System.Drawing.Point(10, 10);
            groupBoxResult.Name = "groupBoxResult";
            groupBoxResult.Size = new System.Drawing.Size(980, 228);
            groupBoxResult.TabIndex = 0;
            groupBoxResult.TabStop = false;
            groupBoxResult.Text = "处理结果";
            // 
            // txtResult
            // 
            txtResult.Font = new System.Drawing.Font("Consolas", 10F);
            txtResult.Location = new System.Drawing.Point(316, 11);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtResult.Size = new System.Drawing.Size(664, 211);
            txtResult.TabIndex = 0;
            // 
            // groupBoxLog
            // 
            groupBoxLog.Controls.Add(txtLog);
            groupBoxLog.Controls.Add(btnClearLog);
            groupBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBoxLog.Location = new System.Drawing.Point(10, 10);
            groupBoxLog.Name = "groupBoxLog";
            groupBoxLog.Size = new System.Drawing.Size(980, 640);
            groupBoxLog.TabIndex = 1;
            groupBoxLog.TabStop = false;
            groupBoxLog.Text = "运行日志";
            // 
            // txtLog
            // 
            txtLog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txtLog.Font = new System.Drawing.Font("Consolas", 10F);
            txtLog.Location = new System.Drawing.Point(316, 234);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtLog.Size = new System.Drawing.Size(661, 413);
            txtLog.TabIndex = 0;
            // 
            // btnClearLog
            // 
            btnClearLog.BackColor = System.Drawing.Color.LightGray;
            btnClearLog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            btnClearLog.Location = new System.Drawing.Point(200, 10);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new System.Drawing.Size(80, 28);
            btnClearLog.TabIndex = 1;
            btnClearLog.Text = "清空日志";
            btnClearLog.UseVisualStyleBackColor = false;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new System.Drawing.Point(0, 660);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(1000, 22);
            statusStrip.TabIndex = 2;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new System.Drawing.Size(32, 17);
            toolStripStatusLabel.Text = "就绪";
            // 
            // progressBar
            // 
            progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            progressBar.Location = new System.Drawing.Point(0, 682);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(1000, 18);
            progressBar.TabIndex = 3;
            // 
            // MainForm
            // 
            ClientSize = new System.Drawing.Size(1000, 700);
            Controls.Add(panelLeft);
            Controls.Add(panelRight);
            Controls.Add(statusStrip);
            Controls.Add(progressBar);
            MinimumSize = new System.Drawing.Size(900, 600);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "考勤数据处理程序";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            groupBoxRange.ResumeLayout(false);
            groupBoxRange.PerformLayout();
            groupBoxFile.ResumeLayout(false);
            groupBoxFile.PerformLayout();
            groupBoxVersion.ResumeLayout(false);
            groupBoxVersion.PerformLayout();
            panelRight.ResumeLayout(false);
            groupBoxResult.ResumeLayout(false);
            groupBoxResult.PerformLayout();
            groupBoxLog.ResumeLayout(false);
            groupBoxLog.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
} 