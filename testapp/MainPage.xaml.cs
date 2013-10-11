﻿using System;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {


        public MainPage()
        {
            InitializeComponent();

            name_lbl.Content = User.name;
            pswd_lbl.Content = User.password;
            if (!pos_lbl.Content.Equals("manager"))
            {
                //bug_txt_blk.Visibility = System.Windows.Visibility.Collapsed;
                prjct_txt_blk.Visibility = System.Windows.Visibility.Collapsed;
                user_txt_blk.Visibility = System.Windows.Visibility.Collapsed;
            }
           
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var newMainWindow = new MainWindow();
            newMainWindow.Show();
        }

        /*private void click(object sender, RoutedEventArgs e)
        {
            var bug = new BugPage();
            this.NavigationService.Navigate(bug);
        }*/


    }
}
