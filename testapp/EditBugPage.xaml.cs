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

namespace testapp
{
    /// <summary>
    /// Interaction logic for BugPage.xaml
    /// </summary>
    public partial class BugPage : Page
    {
        public BugPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var mainPage = new MainPage();
            this.NavigationService.Navigate(mainPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var mainPage = new MainPage();
            this.NavigationService.Navigate(mainPage);
        }
    }
}
