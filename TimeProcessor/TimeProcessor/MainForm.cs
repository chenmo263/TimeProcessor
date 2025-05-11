using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace TimeProcessor
{
    public partial class MainForm : Form
    {
        private string inputFilePath = string.Empty;
        private string outputFilePath = string.Empty;
        private SettingsModel settings;
        private string settingsPath = "appsettings.json";

        public MainForm()
        {
            InitializeComponent();
            btnSelectFile.Click += BtnSelectFile_Click;
            btnProcess.Click += BtnProcess_Click;
            btnProcess.Enabled = false;
            btnSettings.Click += BtnSettings_Click;
            btnAbout.Click += BtnAbout_Click;
            btnClearLog.Click += (s, e) => { txtLog.Clear(); };
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                settings = SettingsManager.LoadSettings(settingsPath);
                Log("设置加载成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载设置失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                settings = new SettingsModel();
            }
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "选择Excel文件";
                ofd.Filter = "Excel文件|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputFilePath = ofd.FileName;
                    var sfd = new SaveFileDialog();
                    sfd.Title = "选择保存位置";
                    sfd.Filter = "Excel文件|*.xlsx;*.xls";
                    sfd.FileName = Path.GetFileNameWithoutExtension(inputFilePath) + "_处理结果" + Path.GetExtension(inputFilePath);
                    sfd.InitialDirectory = Path.GetDirectoryName(inputFilePath);
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        outputFilePath = sfd.FileName;
                        lblFileInfo.Text = $"输入文件：{Path.GetFileName(inputFilePath)}\n输出文件：{Path.GetFileName(outputFilePath)}";
                        btnProcess.Enabled = true;
                        Log($"已选择输入文件：{inputFilePath}");
                    }
                }
            }
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputFilePath) || string.IsNullOrEmpty(outputFilePath))
            {
                MessageBox.Show("请先选择文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                txtResult.Clear();
                txtLog.Clear();
                toolStripStatusLabel.Text = "正在处理...";
                progressBar.Value = 0;
                Log($"开始处理数据：{inputFilePath}");

                // 获取用户输入的行列范围
                int startRow = int.Parse(txtStartRow.Text.Trim());
                int endRow = int.Parse(txtEndRow.Text.Trim());
                int startCol = ExcelHelper.ColumnLetterToIndex(txtStartCol.Text.Trim());
                int endCol = ExcelHelper.ColumnLetterToIndex(txtEndCol.Text.Trim());
                if (startRow < 1 || endRow < startRow || startCol < 1 || endCol < startCol)
                    throw new Exception("请输入有效的行列范围！");

                // 读取Excel指定范围
                DataTable dt = ExcelHelper.ReadExcel(inputFilePath, startRow, endRow, startCol, endCol);
                Log($"已读取 {dt.Rows.Count} 行，{dt.Columns.Count} 列。");

                // 读取工作时间设置（从settings对象）
                var workTimes = new Dictionary<string, string>
                {
                    {"morning_start", settings.work_times.morning_start},
                    {"noon_end", settings.work_times.noon_end},
                    {"afternoon_start", settings.work_times.afternoon_start},
                    {"evening_end", settings.work_times.evening_end}
                };

                // 结果表：每列一个工作时长
                DataTable resultTable = new DataTable();
                for (int c = 0; c < dt.Columns.Count; c++)
                    resultTable.Columns.Add();
                var resultRow = resultTable.NewRow();

                // 处理每列
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    string cellValue = dt.Rows[0][c]?.ToString();
                    Log($"原始单元格内容: {cellValue}");
                    var times = TimeProcessor.SplitAndCleanTimes(cellValue);
                    Log($"提取到的时间: {string.Join(",", times)}");
                    var categorized = TimeProcessor.CategorizeTimes(times);
                    Log($"分类结果: {string.Join(",",categorized.Select(kv => kv.Key + ":" + kv.Value))}");
                    double hours = TimeProcessor.CalculateWorkHours(categorized, workTimes);
                    Log($"计算结果: {hours}");
                    resultRow[c] = hours;
                    txtResult.AppendText($"列{c + startCol} 原始: {cellValue}\r\n");
                    txtResult.AppendText($"  早上上班: {categorized["早上上班时间"]}  中午下班: {categorized["中午下班时间"]}\r\n");
                    txtResult.AppendText($"  下午上班: {categorized["下午上班时间"]}  晚上下班: {categorized["晚上下班时间"]}\r\n");
                    txtResult.AppendText($"  工作时长: {hours} 小时\r\n-----------------------------\r\n");
                    progressBar.Value = (int)(100.0 * (c + 1) / dt.Columns.Count);
                }
                resultTable.Rows.Add(resultRow);
                ExcelHelper.SaveExcel(resultTable, outputFilePath);
                Log($"结果已保存到：{outputFilePath}");
                toolStripStatusLabel.Text = "处理完成";
                progressBar.Value = 0;
            }
            catch (Exception ex)
            {
                Log($"错误：{ex.Message}");
                toolStripStatusLabel.Text = "处理失败";
                progressBar.Value = 0;
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteErrorLog(ex);
            }
        }

        private void WriteErrorLog(Exception ex)
        {
            try
            {
                string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
                if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
                string logFile = Path.Combine(logDir, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
                File.AppendAllText(logFile, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex}\r\n");
            }
            catch { }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm(settings, settingsPath, this);
            form.ShowDialog();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        public void ReloadSettings()
        {
            LoadSettings();
        }

        private void Log(string message)
        {
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n");
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }
    }
} 