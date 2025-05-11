using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimeProcessor
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            this.Text = "关于";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Width = 440;
            this.Height = 420;
            this.BackColor = Color.WhiteSmoke;

            // 标题
            Label lblTitle = new Label
            {
                Text = "考勤数据处理程序",
                Font = new Font("微软雅黑", 18, FontStyle.Bold),
                ForeColor = Color.Teal,
                AutoSize = true,
                Top = 22,
                Left = 30
            };
            this.Controls.Add(lblTitle);

            // 主要信息
            GroupBox groupInfo = new GroupBox
            {
                Text = "程序信息",
                Font = new Font("微软雅黑", 10, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Left = 20,
                Top = 70,
                Width = 380,
                Height = 110,
                BackColor = Color.White
            };
            this.Controls.Add(groupInfo);

            Label lblVersion = new Label { Text = "版本：1.0.0", Font = new Font("微软雅黑", 10), AutoSize = true, Top = 30, Left = 20 };
            Label lblAuthor = new Label { Text = "作者：陈默", Font = new Font("微软雅黑", 10), AutoSize = true, Top = 55, Left = 20 };
            LinkLabel lblContact = new LinkLabel { Text = "联系方式：chenmo@chenmo2.com", Font = new Font("微软雅黑", 10), AutoSize = true, Top = 80, Left = 20 };
            lblContact.LinkClicked += (s, e) => System.Diagnostics.Process.Start("mailto:chenmo@chenmo2.com");
            groupInfo.Controls.Add(lblVersion);
            groupInfo.Controls.Add(lblAuthor);
            groupInfo.Controls.Add(lblContact);

            // 更新日志
            GroupBox groupLog = new GroupBox
            {
                Text = "更新日志",
                Font = new Font("微软雅黑", 10, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Left = 20,
                Top = 190,
                Width = 380,
                Height = 130,
                BackColor = Color.White
            };
            this.Controls.Add(groupLog);

            TextBox txtLog = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Top = 25,
                Left = 15,
                Width = 340,
                Height = 85,
                Font = new Font("微软雅黑", 9),
                Text = "1.0.0 初始版本\r\n1.1.0 支持自定义设置\r\n1.2.0 优化界面和日志功能"
            };
            groupLog.Controls.Add(txtLog);

            // 确定按钮
            Button btnOK = new Button
            {
                Text = "确定",
                Width = 100,
                Height = 36,
                Top = 340,
                Left = 150,
                Font = new Font("微软雅黑", 12, FontStyle.Bold),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.OK
            };
            btnOK.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnOK);
        }

        private void InitializeComponent()
        {

        }
    }
} 