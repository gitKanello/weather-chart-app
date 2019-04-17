using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WeatherChartApp
{
    static class Utils
    {
        public static Dictionary<DateTime,double> ExtractFromTxt()
        {
            Dictionary<DateTime, double> temp = new Dictionary<DateTime, double>();
            string line;
            //string[] temps;
            //StreamReader file = new StreamReader(@"C:\Users\turbox\Desktop\Εργαστηριακή32\TempartureLogsTELIKO.txt"); //b1shr.txt
            StreamReader file = new StreamReader(@"C:\Users\turbox\Desktop\Εργαστηριακή32\b1shr.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] temps = line.Split(';');
                temp.Add(DateTime.Parse(temps[0]), double.Parse(temps[1]));
            }
            return temp;
        }
    }
}