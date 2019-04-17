using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherChartApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            EventHandling.SetTimer(form);
            //System.Threading.Thread.Sleep(10000);
            Application.Run();
        }
        
        public enum Type
        {
            Now = 1,
            Before = 0
        }
    }
}   
