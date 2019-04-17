using System;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Collections.Generic;
using System.Linq;

namespace WeatherChartApp
{
    public partial class Form1 : Form
    {
        private static int count = 0;

        public Form1()
        {
            InitializeComponent();
            this.Visible = true;
           
            //cartesianChart1.Series = new SeriesCollection
            //{
            //    new LineSeries
            //    {
            //        Title = "Current",
            //        //Values = new ChartValues<DateTimePoint>
            //        //{
            //        //    new DateTimePoint(),
            //        //},
            //    }
            //};

            //AddSeries((int)Program.Type.Now, DateTime.Now, double.Parse(nap));
            SetHistory();
            //SetCurrentSeries();


            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Date",
                LabelFormatter = val => new System.DateTime((long)val).ToString("MM:dd:yyyy")
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Price",
                LabelFormatter = value => value.ToString()
            });

            
             //cartesianChart1.LegendLocation = LegendLocation.Right;
             // cartesianChart1.DataClick += CartesianChart1OnDataClick;
        }

        //private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        //{
        //    MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        //}

        public void AddSeries(int num, DateTime time, double value)
        {
            try
            {
                cartesianChart1.Series[num].Values.Add(new DateTimePoint(time, value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(num + "  " + ex.ToString());
            }
        }

        public void SetHistory()
        {
            Dictionary<DateTime, double> seriesValues = new Dictionary<DateTime, double>();
            seriesValues = Utils.ExtractFromTxt(); 
            for (int i = 0; i < seriesValues.Count - 1; i++)
            {
                var item = seriesValues.ElementAt(i);
                if (i == 0)
                {
                    cartesianChart1.Series.Add(new LineSeries
                    {
                        Title = "History",
                        Values = new ChartValues<DateTimePoint> { new DateTimePoint(item.Key, item.Value) },
                        LineSmoothness = 0,
                    });
                }
                else
                {
                    AddSeries((int)Program.Type.Before, item.Key, item.Value);
                }
            }
        }

        public void SetCurrentSeries()
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Current",
                }
            };
        }
    }
}


//modifying the series collection will animate and update the chart
//cartesianChart1.Series.Add(new LineSeries
//{
//    Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
//    LineSmoothness = 0, //straight lines, 1 really smooth lines
//    PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
//    PointGeometrySize = 50,
//    PointForeground = Brushes.Gray
//});