//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForecastApp.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Forecast
    {
        public string level0 { get; set; }
        public string level1 { get; set; }
        public string level2 { get; set; }
        public string level3 { get; set; }
        public string level4 { get; set; }
        public string itemname { get; set; }
        public string itemid { get; set; }
        public string inventlocationid { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<double> qty20 { get; set; }
        public Nullable<double> forecast20 { get; set; }
        public Nullable<double> qty19 { get; set; }
        public int id { get; set; }
        public Nullable<double> coefficient { get; set; }
    }
}
