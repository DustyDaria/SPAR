using ForecastApp.ViewModels.Controls.Menu;
using ForecastApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.Services.Commands.MenuClick
{
    internal class OpenStatisticInfoViewCommand : MyCommand
    {
        public OpenStatisticInfoViewCommand(CtrlBurgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new StatisticInfo_View());
    }
}
