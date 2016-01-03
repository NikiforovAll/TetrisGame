using System;
using System.Windows.Forms;

namespace TetrisForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 mainForm = new Form1();
            mainForm.GameInfo.MainForm = mainForm;
            Application.Run(mainForm);
        }
    }
}
