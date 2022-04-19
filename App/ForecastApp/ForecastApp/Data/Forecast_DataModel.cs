using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForecastApp.Data
{
    public class Forecast_DataModel
    {
        public int id { get; set; }
        public string level0 { get; set; }
        public string level1 { get; set; }
        public string level2 { get; set; }
        public string level3 { get; set; }
        public string level4 { get; set; }
        public string inventLocationId { get; set; }
        public string itemId { get; set; }
        public string itemName { get; set; }
        public DateTime? date { get; set; }
        public double qty20 { get; set; }
        public double qty19 { get; set; }
        public double forecast20 { get; set; }

        public string FullItemName
        {
            get => $"{ itemId }:{  itemName }";
            set
            {
                try
                {
                    string[] fullName = value.Split(new char[] { ':' });
                    itemId = fullName[0];
                    itemName = fullName[1];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла непредвиденная ошибка: " + ex.ToString());
                }
            }
        }
    }
}
