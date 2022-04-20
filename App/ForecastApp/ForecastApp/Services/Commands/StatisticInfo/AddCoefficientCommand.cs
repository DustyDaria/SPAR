using ForecastApp.Data;
using ForecastApp.Models;
using ForecastApp.Services.Commands.Base;
using ForecastApp.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForecastApp.Services.Commands.StatisticInfo
{
    internal class AddCoefficientCommand : MyCommand
    {
        private Forecast_Model _model = new Forecast_Model();
        private Forecast_DataModel _dataModel = new Forecast_DataModel();
        Entities.ForecastEntities _context = new Entities.ForecastEntities();

        public AddCoefficientCommand(StatisticInfo_ViewModel _viewModel) : base(_viewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => AddData();

        private void AddData()
        {
            try
            {
                _dataModel.FullItemName = _viewModel.ItemDataSelected;
                double coef = Convert.ToDouble(_viewModel.Сoefficient);

                var listId = _model.GetAllIdForAddCoefficient(_dataModel.itemId,
                    _viewModel.InventLocationIdSelected, _viewModel.DateStart,
                    _viewModel.DateEnd);
                
                foreach(var i in listId)
                {
                    using(var db = new Entities.ForecastEntities())
                    {
                        var query = db.Forecast
                        .Where(c => c.id == i)
                        .FirstOrDefault();
                        query.coefficient = coef;

                        db.SaveChanges();
                    }
                }
                MessageBox.Show($"Коэффициент \"{coef}\" был успешно добавлен к товару данного магазина за определенный переод времени.\nКоэффициент будет обязательно учтен при расчете прогноза продаж.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!\nКод: " + ex.ToString());
            }
        }
    }
}
