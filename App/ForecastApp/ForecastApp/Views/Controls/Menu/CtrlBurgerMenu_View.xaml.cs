using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ForecastApp.Views.Controls.Menu
{
    /// <summary>
    /// Логика взаимодействия для CtrlBurgerMenu_View.xaml
    /// </summary>
    public partial class CtrlBurgerMenu_View : UserControl
    {
        public CtrlBurgerMenu_View()
        {
            InitializeComponent();
        }

        public Visibility MyVisibility
        {
            get { return (Visibility)GetValue(MyVisibilityProperty); }
            set { SetValue(MyVisibilityProperty, value); }
        }

        public static readonly DependencyProperty MyVisibilityProperty =
            DependencyProperty.Register("MyVisibility", typeof(Visibility),
                typeof(CtrlBurgerMenu_View), new UIPropertyMetadata(Visibility.Collapsed));

        private static void MyPropertyVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
        private void btn_CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btn_OpenMenu.Visibility = Visibility.Visible;
            btn_CloseMenu.Visibility = Visibility.Collapsed;
        }

        private void btn_OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btn_OpenMenu.Visibility = Visibility.Collapsed;
            btn_CloseMenu.Visibility = Visibility.Visible;
        }
    }
}
