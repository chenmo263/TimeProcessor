using System;
using System.Windows.Forms;
using OfficeOpenXml;

namespace TimeProcessor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // EPPlus 8.x 新写法：设置为非商业个人用途（请用你的名字替换）
            ExcelPackage.License.SetNonCommercialPersonal("chenmo");
            //MessageBox.Show("EPPlus License 设置成功！");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            

        }
    }
} 