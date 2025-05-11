using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimeProcessor
{
    public partial class SettingsForm : Form
    {
        private TextBox txtMorningStart, txtNoonEnd, txtAfternoonStart, txtEveningEnd;
        private TextBox txtValidMorningStart, txtValidMorningEnd, txtValidNoonStart, txtValidNoonEnd, txtValidAfternoonStart, txtValidAfternoonEnd, txtValidEveningStart, txtValidEveningEnd;
        private CheckBox chkAutoBackup, chkConfirmOverwrite;
        private Button btnSave;
        private SettingsModel settings;
        private string settingsPath;
        private MainForm mainForm;

        public SettingsForm(SettingsModel settings, string settingsPath, MainForm mainForm)
        {
            this.settings = settings;
            this.settingsPath = settingsPath;
            this.mainForm = mainForm;

            this.Text = "设置";
            this.Width = 520;
            this.Height = 570;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.WhiteSmoke;

            // 标题
            Label lblTitle = new Label
            {
                Text = "系统设置",
                Font = new Font("微软雅黑", 18, FontStyle.Bold),
                ForeColor = Color.Teal,
                AutoSize = true,
                Left = 30,
                Top = 18
            };
            this.Controls.Add(lblTitle);

            // 工作时间分组
            GroupBox groupWork = new GroupBox
            {
                Text = "工作时间",
                Font = new Font("微软雅黑", 10, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Left = 20,
                Top = 60,
                Width = 460,
                Height = 110,
                BackColor = Color.White
            };
            this.Controls.Add(groupWork);

            txtMorningStart = AddLabeledTextBox(groupWork, "早上上班", 20, 30, settings.work_times.morning_start);
            txtNoonEnd = AddLabeledTextBox(groupWork, "中午下班", 240, 30, settings.work_times.noon_end);
            txtAfternoonStart = AddLabeledTextBox(groupWork, "下午上班", 20, 65, settings.work_times.afternoon_start);
            txtEveningEnd = AddLabeledTextBox(groupWork, "晚上下班", 240, 65, settings.work_times.evening_end);

            // 有效打卡时间分组
            GroupBox groupValid = new GroupBox
            {
                Text = "有效打卡时间",
                Font = new Font("微软雅黑", 10, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Left = 20,
                Top = 180,
                Width = 460,
                Height = 140,
                BackColor = Color.White
            };
            this.Controls.Add(groupValid);

            txtValidMorningStart = AddLabeledTextBox(groupValid, "早上上班", 20, 30, settings.valid_times.morning.start, 60);
            txtValidMorningEnd = AddLabeledTextBox(groupValid, "至", 110, 30, settings.valid_times.morning.end, 60);
            txtValidNoonStart = AddLabeledTextBox(groupValid, "中午下班", 240, 30, settings.valid_times.noon.start, 60);
            txtValidNoonEnd = AddLabeledTextBox(groupValid, "至", 330, 30, settings.valid_times.noon.end, 60);

            txtValidAfternoonStart = AddLabeledTextBox(groupValid, "下午上班", 20, 75, settings.valid_times.afternoon.start, 60);
            txtValidAfternoonEnd = AddLabeledTextBox(groupValid, "至", 110, 75, settings.valid_times.afternoon.end, 60);
            txtValidEveningStart = AddLabeledTextBox(groupValid, "晚上下班", 240, 75, settings.valid_times.evening.start, 60);
            txtValidEveningEnd = AddLabeledTextBox(groupValid, "至", 330, 75, settings.valid_times.evening.end, 60);

            // 文件设置分组
            GroupBox groupFile = new GroupBox
            {
                Text = "文件设置",
                Font = new Font("微软雅黑", 10, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Left = 20,
                Top = 330,
                Width = 460,
                Height = 80,
                BackColor = Color.White
            };
            this.Controls.Add(groupFile);

            chkAutoBackup = new CheckBox
            {
                Text = "处理前自动备份原文件",
                Left = 30,
                Top = 30,
                Width = 200,
                Checked = settings.file_settings.auto_backup,
                Font = new Font("微软雅黑", 10)
            };
            groupFile.Controls.Add(chkAutoBackup);

            chkConfirmOverwrite = new CheckBox
            {
                Text = "覆盖文件时需要确认",
                Left = 240,
                Top = 30,
                Width = 180,
                Checked = settings.file_settings.confirm_overwrite,
                Font = new Font("微软雅黑", 10)
            };
            groupFile.Controls.Add(chkConfirmOverwrite);

            // 保存按钮
            btnSave = new Button
            {
                Text = "保存",
                Left = 200,
                Top = 440,
                Width = 100,
                Height = 36,
                Font = new Font("微软雅黑", 12, FontStyle.Bold),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);
        }

        private TextBox AddLabeledTextBox(Control parent, string label, int left, int top, string value, int width = 80)
        {
            Label lbl = new Label
            {
                Text = label,
                Left = left,
                Top = top + 3,
                Width = 60,
                Font = new Font("微软雅黑", 10)
            };
            parent.Controls.Add(lbl);
            TextBox txt = new TextBox
            {
                Left = left + 55,
                Top = top,
                Width = width,
                Font = new Font("微软雅黑", 10),
                Text = value
            };
            parent.Controls.Add(txt);
            return txt;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            settings.work_times.morning_start = txtMorningStart.Text.Trim();
            settings.work_times.noon_end = txtNoonEnd.Text.Trim();
            settings.work_times.afternoon_start = txtAfternoonStart.Text.Trim();
            settings.work_times.evening_end = txtEveningEnd.Text.Trim();
            settings.valid_times.morning.start = txtValidMorningStart.Text.Trim();
            settings.valid_times.morning.end = txtValidMorningEnd.Text.Trim();
            settings.valid_times.noon.start = txtValidNoonStart.Text.Trim();
            settings.valid_times.noon.end = txtValidNoonEnd.Text.Trim();
            settings.valid_times.afternoon.start = txtValidAfternoonStart.Text.Trim();
            settings.valid_times.afternoon.end = txtValidAfternoonEnd.Text.Trim();
            settings.valid_times.evening.start = txtValidEveningStart.Text.Trim();
            settings.valid_times.evening.end = txtValidEveningEnd.Text.Trim();
            settings.file_settings.auto_backup = chkAutoBackup.Checked;
            settings.file_settings.confirm_overwrite = chkConfirmOverwrite.Checked;
            SettingsManager.SaveSettings(settingsPath, settings);
            mainForm.ReloadSettings();
            MessageBox.Show("设置已保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
} 