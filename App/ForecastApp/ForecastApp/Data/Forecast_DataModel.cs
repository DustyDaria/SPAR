using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public float? qty20 { get; set; }
        public float? qty19 { get; set; }
        public float? forecast20 { get; set; }

    }
}
