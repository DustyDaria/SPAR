using ForecastApp.Data;
using ForecastApp.Models;
using ForecastApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.ViewModels.Pages
{
    public class StatisticInfo_ViewModel : ViewModel
    {
        private IndicatorsCompany_Model _indicatorsModel = new IndicatorsCompany_Model();
        private StatisticInfo_Model _statisticModel = new StatisticInfo_Model();
        private Forecast_DataModel _dataModel = new Forecast_DataModel();
        public StatisticInfo_ViewModel()
        {
            #region Загрузка данных
            ItemDataList = new List<string>(_indicatorsModel
                .GetAllItem(_indicatorsModel
                .GetAllId()));
            if (ItemDataList.Count > 0)
                ItemDataSelected = ItemDataList.First();

            InventLocationList = new List<string>(_indicatorsModel
                .GetAllInventLocationId());
            if (InventLocationList.Count > 0)
                InventLocationIdSelected = InventLocationList.First();

            this.CalculateFunc();
            #endregion
        }

        private void CalculateFunc()
        {
            #region Среднее арифметическое
            double sumForAvg20 = 0;
            double sumForAvg19 = 0;

            _dataModel.FullItemName = ItemDataSelected;
            var listQty20 = _indicatorsModel.GetQty20ForItem(_dataModel.itemId,
                DateStart, DateEnd, InventLocationIdSelected);
            var listQty19 = _indicatorsModel.GetQty19ForItem(_dataModel.itemId,
                DateStart, DateEnd, InventLocationIdSelected);

            foreach (var i in listQty20)
                sumForAvg20 += i;
            foreach (var i in listQty19)
                sumForAvg19 += i;

            Avg20 = sumForAvg20 / listQty20.Count;
            Avg19 = sumForAvg19 / listQty19.Count;
            #endregion

            #region Ошибки прогноза
            List<double> listAbs = new List<double>();
            double sumForAbsAvg = 0;

            var listForecast20 = _indicatorsModel.GetForecast20ForItem(_dataModel.itemId,
                DateStart, DateEnd, InventLocationIdSelected);

            for(int i = 0; i < listQty20.Count; i++)
            {
                if (listQty20[i] == 0)
                    listAbs.Add(Math.Abs(0));
                else
                    listAbs.Add(Math.Abs((listQty20[i]-listForecast20[i])/listQty20[i]));
            }
            foreach (var i in listAbs)
                sumForAbsAvg += i;

            ErrorForecast = sumForAbsAvg / listAbs.Count;

            #endregion
        }

        private static double _avg20;
        /// <summary>
        /// Среднее арифметическое продаж (текущий год)
        /// </summary>
        public double Avg20
        {
            get => _avg20;
            set => Set(ref _avg20, value);
        }

        private static double _avg19;
        /// <summary>
        /// Среднее арифметическое продаж (прошлый год)
        /// </summary>
        public double Avg19
        {
            get => _avg19;
            set => Set(ref _avg19, value);
        }

        private static double _errorForecast;
        /// <summary>
        /// Среднее арифметическое продаж (прошлый год)
        /// </summary>
        public double ErrorForecast
        {
            get => _errorForecast;
            set => Set(ref _errorForecast, value);
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


        private static List<string> _inventLocationList;
        /// <summary>
        /// Список id магазинов
        /// </summary>
        public List<string> InventLocationList
        {
            get => _inventLocationList;
            set => Set(ref _inventLocationList, value);
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

    }
}
