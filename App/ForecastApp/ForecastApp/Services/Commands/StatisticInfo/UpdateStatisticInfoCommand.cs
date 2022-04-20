using ForecastApp.Data;
using ForecastApp.Models;
using ForecastApp.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForecastApp.Services.Commands.StatisticInfo
{
    internal class UpdateStatisticInfoCommand : MyCommand
    {
        private Forecast_Model _model = new Forecast_Model();
        private Forecast_DataModel _dataModel = new Forecast_DataModel();
        Entities.ForecastEntities _context = new Entities.ForecastEntities();

        public UpdateStatisticInfoCommand(StatisticInfo_ViewModel _viewModel) : base(_viewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UpdateData();

        private void UpdateData()
        {
            try
            {
                _viewModel.CalculateFunc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!\nКод: " + ex.ToString());
            }
        }
    }
}
