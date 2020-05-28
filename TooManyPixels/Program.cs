using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TooManyPixels
{
    internal static class Program
    {
        internal static TooManyPixelsForm Form;

        [STAThread]
        internal static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Form = new TooManyPixelsForm());
        }
    }
}
