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
using System.Data.SQLite;
namespace testapp
{
    /// <summary>
    /// Interaction logic for ProfileEditPage.xaml
    /// </summary>
    public partial class ProfileEditPage : Page
    {
        public ProfileEditPage()
        {
            InitializeComponent();
            profile_edit_idLbl.Content = User.Id;
            profile_edit_nameTb.Text = User.name;
            profile_edit_lnTb.Text = User.last_name;
            profile_edit_passTb.Text = User.password;
            profile_edit_posLbl.Content = User.position;
        }

        private void Button_Click_Abort(object sender, RoutedEventArgs e)
        {
            var mainPage = new MainPage();
            this.NavigationService.Navigate(mainPage);
        }

        private void Button_Click_Send(object sender, RoutedEventArgs e)
        {
            //déclaration du chemin de la base de donnée 
            string dbConnectionString = @"Data source=database.db;Version=3;";
            SQLiteConnection sqlCon = new SQLiteConnection(dbConnectionString);
            //ouverture de la connection à la base de donnée
            try
            {
                sqlCon.Open();
                //declaration du script de la mise à jours
                string query = "Update user set name='" + profile_edit_nameTb.Text+"',last_name='"+
                    profile_edit_lnTb.Text + "',password='" + profile_edit_passTb.Text+"' where id='"+User.Id+"';";
                //creation d'une commande et execution de la requette 
                SQLiteCommand comm = new SQLiteCommand(query, sqlCon);
                comm.ExecuteNonQuery();
                MessageBox.Show("entry edited");

                //fermeture de la connexion à la BD
                sqlCon.Close();

                //mise à jour des informations du profile
                User.name = profile_edit_nameTb.Text;
                User.last_name = profile_edit_lnTb.Text;
                User.password = profile_edit_passTb.Text;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("dbExeption" + ex.Message);
            }

            //retour à la page principale
            var mainPage = new MainPage();
            this.NavigationService.Navigate(mainPage);
        }

       
    }
}
