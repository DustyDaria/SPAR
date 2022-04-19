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
        public StatisticInfo_ViewModel()
        {
            #region Загрузка данных
            ItemDataList = new List<string>(_indicatorsModel
                .GetAllItem(_indicatorsModel
                .GetAllId()));
            if (ItemDataList.Count > 0)
                ItemDataSelected = ItemDataList.First();
            #endregion
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
    }
}
