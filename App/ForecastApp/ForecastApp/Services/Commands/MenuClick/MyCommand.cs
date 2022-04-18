using ForecastApp.ViewModels.Controls.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ForecastApp.Services.Commands.MenuClick
{
    /// <summary>
    /// Вспомогательный класс для команд (переключение меню)
    /// </summary>
    abstract class MyCommand : ICommand
    {
        protected CtrlBurgerMenu_ViewModel _ctrlMenu_ViewModel;

        public MyCommand(CtrlBurgerMenu_ViewModel ctrlMenu_ViewModel)
        {
            _ctrlMenu_ViewModel = ctrlMenu_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
