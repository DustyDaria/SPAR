using Caliburn.Micro;
using ForecastApp.Data;
using ForecastApp.Models;
using ForecastApp.Services.Commands.IndicatorsCompany;
using ForecastApp.ViewModels.Base;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ForecastApp.ViewModels.Pages
{
    public class IndicatorsCompany_ViewModel : ViewModel
    {
        private Forecast_Model _model = new Forecast_Model();
        private static DateTime _now = DateTime.Now;

        #region Свойства для графика
        public Func<double, string> yFormatter { get; set; }
        public string[] LabelsDate { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        #endregion

        public IndicatorsCompany_ViewModel()
        {
            this.LoadData();

            this.Cartesian();
        }
        public IndicatorsCompany_ViewModel(BindableCollection<Forecast_DataModel> _forecastData,
            List<string> _itemDataList, List<string> _inventLocationList,
            string _selectItemData, string _selectInventLocation, DateTime _dateStart,
            DateTime _dateEnd, bool _checkQty20, bool _checkQty19, bool _checkForecast20)
        {
            ForecastData = _forecastData;
            ItemDataList = _itemDataList;
            InventLocationList = _inventLocationList;
            ItemDataSelected = _selectItemData;
            InventLocationIdSelected = _selectInventLocation;
            DateStart = _dateStart;
            DateEnd = _dateEnd;
            CheckQty20 = _checkQty20;
            CheckQty19 = _checkQty19;
            CheckForecast20 = _checkForecast20;
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        public void LoadData()
        {
            if (DateStart == new DateTime())
                DateStart = new DateTime(2020, 11, 01);
            if (DateEnd == new DateTime())
                DateEnd = new DateTime(2020, 11, 30);

            ForecastData = new BindableCollection<Forecast_DataModel>(_model
                .GetAllForecast(_model.GetAllId()));

            ItemDataList = new List<string>(_model
                .GetAllItem(_model.GetAllId()));
            if (ItemDataList.Count > 0 && ItemDataSelected == null)
                ItemDataSelected = ItemDataList.First();

            InventLocationList = new List<string>(_model
                .GetAllInventLocationId());
            if (InventLocationList.Count > 0 && InventLocationIdSelected == null)
                InventLocationIdSelected = InventLocationList.First();
        }

        /// <summary>
        /// Прорисовка графика
        /// </summary>
        public void Cartesian()
        {
            var dataModel = new Forecast_DataModel();
            dataModel.FullItemName = ItemDataSelected;

            SeriesCollection = new SeriesCollection();
            if (CheckQty20 == true)
            {
                SeriesCollection.Add(new LineSeries
                {
                    Title = "Факт продаж на текущий год",
                    Values = new ChartValues<double>(_model
                    .GetQty20ForItem(dataModel.itemId, _dateStart,
                        _dateEnd, _inventLocationIdSelected)),
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                });
            }
            if(CheckQty19 == true)
            {
                SeriesCollection.Add(new LineSeries
                {
                    Title = "Факт продаж на прошлый год",
                    Values = new ChartValues<double>(_model
                    .GetQty19ForItem(dataModel.itemId, _dateStart,
                        _dateEnd, _inventLocationIdSelected)),
                    PointGeometry = DefaultGeometries.Triangle,
                    PointGeometrySize = 10
                });
            }
            if(CheckForecast20 == true)
            {
                SeriesCollection.Add(new LineSeries
                {
                    Title = "Прогноз на текущий год",
                    Values = new ChartValues<double>(_model
                    .GetForecast20ForItem(dataModel.itemId, _dateStart,
                        _dateEnd, _inventLocationIdSelected)),
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 10
                });
            }
                
            LabelsDate = _model.GetDateForItem(dataModel.itemId, _dateStart,
                _dateEnd, _inventLocationIdSelected);
            yFormatter = value => value.ToString("");
        }

        private static bool _checkQty20 = true;
        /// <summary>
        /// флаг Qty20
        /// </summary>
        public bool CheckQty20
        {
            get => _checkQty20;
            set => Set(ref _checkQty20, value);
        }

        private static bool _checkQty19 = true;
        /// <summary>
        /// флаг Qty19
        /// </summary>
        public bool CheckQty19
        {
            get => _checkQty19;
            set => Set(ref _checkQty19, value);
        }

        private static bool _checkForecast20 = true;
        /// <summary>
        /// флаг Forecast20
        /// </summary>
        public bool CheckForecast20
        {
            get => _checkForecast20;
            set => Set(ref _checkForecast20, value);
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
        /// Выбранный элемент из списка товаров
        /// </summary>
        public string ItemDataSelected
        {
            get => _itemDataSelected;
            set => Set(ref _itemDataSelected, value);
        }

        private static string _inventLocationIdSelected;
        /// <summary>
        /// Выбранный элемент из списка магазинов
        /// </summary>
        public string InventLocationIdSelected
        {
            get => _inventLocationIdSelected;
            set => Set(ref _inventLocationIdSelected, value);
        }

        private static DateTime _dateStart;
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

        private static DateTime _dateEnd;
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

        private static string _coefficient;
        /// <summary>
        /// Коэффициент повышения/снижения прогноза
        /// </summary>
        public string Сoefficient
        {
            get => _coefficient;
            set => Set(ref _coefficient, value);
        }

        private ICommand _updateIndicatorsCompany;
        /// <summary>
        /// Команда для обновления графиков
        /// </summary>
        public ICommand UpdateIndicatorsCompany
        {
            get
            {
                _updateIndicatorsCompany = new UpdateIndicatorsCompanyCommand(this);
                return _updateIndicatorsCompany;
            }
        }
    }
}
