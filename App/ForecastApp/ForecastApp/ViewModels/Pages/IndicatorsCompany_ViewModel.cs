using Caliburn.Micro;
using ForecastApp.Data;
using ForecastApp.Models;
using ForecastApp.ViewModels.Base;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.ViewModels.Pages
{
    public class IndicatorsCompany_ViewModel : ViewModel
    {
        private IndicatorsCompany_Model _model = new IndicatorsCompany_Model();
        private static DateTime _now = DateTime.Now;

        public IndicatorsCompany_ViewModel()
        {
            #region Загрузка данных
            ForecastData = new BindableCollection<Forecast_DataModel>(_model
                .GetAllForecast(_model.GetAllId()));

            ItemDataList = new List<string>(_model
                .GetAllItem(_model.GetAllId()));
            if (ItemDataList.Count > 0)
                ItemDataSelected = ItemDataList.First();

            InventLocationList = new List<string>(_model
                .GetAllInventLocationId());
            if (InventLocationList.Count > 0)
                InventLocationIdSelected = InventLocationList.First();
            this.Cartesian();
            #endregion
        }

        private static BindableCollection<Forecast_DataModel> _forecastData;
        /// <summary>
        /// Данные для таблицы
        /// </summary>
        public BindableCollection<Forecast_DataModel> ForecastData
        {
            get => _forecastData;
            set => Set(ref _forecastData, value);
        }

        private static List<string> _inventLocationList;
        /// <summary>
        /// Список id магазинов
        /// </summary>
        public List<string> InventLocationList
        {
            get => _inventLocationList;
            set => Set(ref _inventLocationList, value);
        }

        private static List<string> _itemDataList;
        /// <summary>
        /// Список полных имен товаров
        /// </summary>
        public List<string> ItemDataList
        {
            get => _itemDataList;
            set => Set(ref _itemDataList, value);
        }

        private static string _itemDataSelected;
        /// <summary>
        /// Выбранный элемент из списка
        /// </summary>
        public string ItemDataSelected
        {
            get => _itemDataSelected;
            set => Set(ref _itemDataSelected, value);
        }

        private static string _inventLocationIdSelected;

        public string InventLocationIdSelected
        {
            get => _inventLocationIdSelected;
            set => Set(ref _inventLocationIdSelected, value);
        }

        //Для проверки:
        private static DateTime _dateStart = new DateTime(2020, 11, 01);
        // В идеале:
        //private static DateTime _dateStart = new DateTime(_now.Year, _now.Month, 1);
        /// <summary>
        /// Дата начала периода
        /// </summary>
        public DateTime DateStart
        {
            get => _dateStart;
            set => Set(ref _dateStart, value);
        }

        //Для проверки:
        private static DateTime _dateEnd = new DateTime(2020, 11, 30);
        // В идеале:
        //private static DateTime _dateEnd = new DateTime(_now.Year, _now.Month + 1, 1).AddDays(-1);
        /// <summary>
        /// Дата окончания периода
        /// </summary>
        public DateTime DateEnd
        {
            get => _dateEnd;
            set => Set(ref _dateEnd, value);
        }

        private void Cartesian()
        {
            var dataModel = new Forecast_DataModel();
            dataModel.FullItemName = ItemDataSelected;

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title="Факт продаж на текущий год",
                    Values = new ChartValues<double>(_model
                    .GetQty20ForItem(dataModel.itemId, _dateStart, 
                        _dateEnd, _inventLocationIdSelected)),
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize=10
                },
                new LineSeries
                {
                    Title="Факт продаж на прошлый год",
                    Values=new ChartValues<double>(_model
                    .GetQty19ForItem(dataModel.itemId, _dateStart, 
                        _dateEnd, _inventLocationIdSelected)),
                    PointGeometry=DefaultGeometries.Triangle,
                    PointGeometrySize=10
                },
                new LineSeries
                {
                    Title="Прогноз на текущий год",
                    Values=new ChartValues<double>(_model
                    .GetForecast20ForItem(dataModel.itemId, _dateStart, 
                        _dateEnd, _inventLocationIdSelected)),
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize=10
                }
            };
            LabelsDate = _model.GetDateForItem(dataModel.itemId, _dateStart, 
                _dateEnd, _inventLocationIdSelected);
        }

        #region Свойства для графика
        public Func<double> yFormatter { get; set; }
        public string[] LabelsDate { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        #endregion
    }
}
