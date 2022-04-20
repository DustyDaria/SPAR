using ForecastApp.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ForecastApp.Services.Commands.IndicatorsCompany
{
    abstract class MyCommand : ICommand
    {
        protected IndicatorsCompany_ViewModel _viewModel;

        public MyCommand(IndicatorsCompany_ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
