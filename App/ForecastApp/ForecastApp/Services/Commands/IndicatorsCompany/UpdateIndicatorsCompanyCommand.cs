using ForecastApp.ViewModels.Pages;
using ForecastApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForecastApp.Services.Commands.IndicatorsCompany
{
    internal class UpdateIndicatorsCompanyCommand : MyCommand
    {
        public UpdateIndicatorsCompanyCommand(IndicatorsCompany_ViewModel _viewModel) : base(_viewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UpdateData();

        private void UpdateData()
        {
            try
            {
                var forecastData = _viewModel.ForecastData;
                var itemDataList = _viewModel.ItemDataList;
                var inventLocationList = _viewModel.InventLocationList;
                var selectItemData = _viewModel.ItemDataSelected;
                var selectInventLocation = _viewModel.InventLocationIdSelected;
                var dateStart = _viewModel.DateStart;
                var dateEnd = _viewModel.DateEnd;
                var checkQty20 = _viewModel.CheckQty20;
                var checkQty19 = _viewModel.CheckQty19;
                var checkForecast20 = _viewModel.CheckForecast20;

                var vm = new IndicatorsCompany_ViewModel(forecastData, itemDataList,
                    inventLocationList, selectItemData, selectInventLocation, dateStart, dateEnd,
                    checkQty20, checkQty19, checkForecast20);
                
                PageManager.MainFrame.Navigate(new IndicatorsCompany_View());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!\nКод: " + ex.ToString());
            }
        }
    }
}
