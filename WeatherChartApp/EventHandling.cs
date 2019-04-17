using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WeatherChartApp
{
    static class EventHandling
    {
        private static Form1 _form;
        private static System.Timers.Timer aTimer;
        
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
           // string temp = WeatherCall.getWeather().ToString();
            //_form.AddSeries((int)Program.Type.Now, DateTime.Now, double.Parse(temp));
        }

        public static void SetTimer(Form1 form)
        {
            _form = form;
            aTimer = new System.Timers.Timer(5000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
    }
}
