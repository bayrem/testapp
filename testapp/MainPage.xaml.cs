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
using System.Data;

namespace testapp
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        //déclaration du chemin de la base de donnée 
        private static string dbConnectionString = @"Data source=database.db;Version=3;";
        SQLiteConnection sqlCon = new SQLiteConnection(dbConnectionString);


        public MainPage()
        {
            
            InitializeComponent();
            fill_profile_tab();
            fill_users_tab();
            fill_bug_tab();
            if (!pos_lbl.Content.Equals("Manager"))
            {
                prjct_txt_blk.Visibility = System.Windows.Visibility.Collapsed;
                user_txt_blk.Visibility = System.Windows.Visibility.Collapsed;
            }
           
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var newMainWindow = new MainWindow();
            newMainWindow.Show();
        }

        private void fill_profile_tab()
        {
            id_lbl.Content = User.Id;
            name_lbl.Content = User.name;
            lst_nm_lbl.Content = User.last_name;
            pswd_lbl.Content = User.password;
            pos_lbl.Content = User.position;
        }

        private void fill_users_tab()
        {
            //ouverture de la connection à la base de donnée
            try
            {
                sqlCon.Open();
                string query = "Select * from user";
                //SQLiteCommand comm = new SQLiteCommand(query, sqlCon);
                //comm.ExecuteNonQuery();
                //SQLiteDataReader dReader = comm.ExecuteReader();
                SQLiteDataAdapter dba = new SQLiteDataAdapter(query, sqlCon);
                DataSet dSet = new DataSet();
                dba.Fill(dSet, "user");
                sqlCon.Close();
                DataTable dt = dSet.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    int i = 0;
                    foreach (DataColumn column in dt.Columns)
                    {
                        try
                        {
                            i++;
                            usr_lstview.Items.Add(row[i].ToString());
                        }
                        catch
                        {

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("dbExeption" + ex.Message);
            }
        }

        private void fill_bug_tab()
        {
            //ouverture de la connection à la base de donnée
            try
            {
                sqlCon.Open();
                string query = "Select * from bug";
                //SQLiteCommand comm = new SQLiteCommand(query, sqlCon);
                //comm.ExecuteNonQuery();
                //SQLiteDataReader dReader = comm.ExecuteReader();
                SQLiteDataAdapter dba = new SQLiteDataAdapter(query, sqlCon);
                DataSet dSet = new DataSet();
                dba.Fill(dSet, "bug");
                sqlCon.Close();
                DataTable dt = dSet.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    int i = 0;
                    foreach (DataColumn column in dt.Columns)
                    {
                        try
                        {
                            i++;
                            bug_lstview.Items.Add(row[i].ToString());
                        }
                        catch
                        {

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("dbExeption" + ex.Message);
            }
        }


    }
}
