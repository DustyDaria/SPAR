using Caliburn.Micro;
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
    public class IndicatorsCompany_ViewModel : ViewModel
    {
        public IndicatorsCompany_ViewModel()
        {
            #region Загрузка данных
            IndicatorsCompany_Model _model = new IndicatorsCompany_Model();
            ForecastData = new BindableCollection<Forecast_DataModel>(_model
                .GetAllForecast(_model.GetAllId()));
            #endregion
        }

        private BindableCollection<Forecast_DataModel> _forecastData;
        public BindableCollection<Forecast_DataModel> ForecastData
        {
            get => _forecastData;
            set => Set(ref _forecastData, value);
        }
    }
}
