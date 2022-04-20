using ForecastApp.Services;
using ForecastApp.Services.Commands.MenuClick;
using ForecastApp.ViewModels.Base;
using ForecastApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ForecastApp.ViewModels.Controls.Menu
{
    public class CtrlBurgerMenu_ViewModel : ViewModel
    {
        private ICommand _openIndicatorsCompanyView;
        /// <summary>
        /// Команда обработки нажатия (Показатели компании)
        /// </summary>
        public ICommand OpenIndicatorsCompanyView
        {
            get
            {
                if (_openIndicatorsCompanyView == null)
                {
                    _openIndicatorsCompanyView = new OpenIndicatorsCompanyViewCommand(this);
                }
                return _openIndicatorsCompanyView;
            }
        }

        private ICommand _openStatisticInfoView;
        /// <summary>
        /// Команда обработки нажатия (Информация о статистиках)
        /// </summary>
        public ICommand OpenStatisticInfoView
        {
            get
            {
                if(_openStatisticInfoView == null)
                {
                    _openStatisticInfoView = new OpenStatisticInfoViewCommand(this);
                }
                return _openStatisticInfoView;
            }
        }   
    }
}
