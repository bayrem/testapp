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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
          
            if (!usernameTB.Text.Equals("") && !PasswordBoxPB.Password.Equals(""))
            {
                if (usernameTB.Text.Equals("Bayrem") && PasswordBoxPB.Password.Equals("bibo"))
                {
                    var newWindow = new Window1(usernameTB.Text);
                    newWindow.Show();
                    this.Close();
                    /*
                    mainImage.Visibility = Visibility.Visible;
                    LoginBTN.Visibility = Visibility.Collapsed;
                    //logoutBTN.Visibility = Visibility.Visible;
                     */
                }
                else
                    MessageBox.Show("Wrong Password");
            }
            else
                MessageBox.Show("Wrong Info"); 
            
        }
    }
}
