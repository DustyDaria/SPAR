using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ForecastApp.Services.Commands.Base
{
    public abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        // Если данная функция возвращает ложь, то команду выполнить нельзя 
        // -> элемент, к которому привязана команда, отключается автоматически

        public abstract bool CanExecute(object parameter);

        // Данный метод реализует основную логику команды
        public abstract void Execute(object parameter);
    }
}
