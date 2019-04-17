using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace WeatherChartApp
{
    static class WeatherCall
    {
        public static string getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q=London&appid=6d6fbd77236e01c78fd6f3eb9837373c&units=metric&cnt=6");
                var json = web.DownloadString(url);
                WeatherInfo.code scd = JsonConvert.DeserializeObject<WeatherInfo.code>(json);
                double currTemp = scd.main.temp;
                return currTemp.ToString();
            }
        }
    }
}
