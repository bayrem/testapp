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
    /// Interaction logic for AddBugPage.xaml
    /// </summary>
    public partial class AddBugPage : Page
    {
        //déclaration du chemin de la base de donnée 
        private static string dbConnectionString = @"Data source=database.db;Version=3;";
        SQLiteConnection sqlCon = new SQLiteConnection(dbConnectionString);
        public AddBugPage()
        {
            InitializeComponent();
            fillCombobox();
            add_bug_typeCB.Items.Add("crash");
            add_bug_typeCB.Items.Add("major");
            add_bug_typeCB.Items.Add("trevial");
            add_bug_typeCB.Items.Add("minor");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var mainPage = new MainPage();
            this.NavigationService.Navigate(mainPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            //ouverture de la connection à la base de donnée
            try
            {
                sqlCon.Open();
                //declaration du script de la mise à jours
                string query = "insert into bug(prjct_id,reporter_id,type,state,desc) values('" + retrieveId(add_bug_prjctCB.SelectedItem.ToString()) + "','" +
                    User.Id + "','" + add_bug_typeCB.SelectedItem + "','new','"
                    +add_bug_Tbox.Text+"');";
                //creation d'une commande et execution de la requette 
                SQLiteCommand comm = new SQLiteCommand(query, sqlCon);
                comm.ExecuteNonQuery();
                MessageBox.Show("entry edited");

                //fermeture de la connexion à la BD
                sqlCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("dbExeption" + ex.Message);
            }
            //retour à la page principale
            var mainPage = new MainPage();
            this.NavigationService.Navigate(mainPage);
        }

        //methode pour recuperer le id d'un champ text
        private int retrieveId(string txt)
        {
            
            int id =0;
            //ouverture de la connection à la base de donnée
            try
            {
                sqlCon.Open();
                string query = "Select id from project where project_name = '"+txt+"';";
                SQLiteCommand comm = new SQLiteCommand(query, sqlCon);
                comm.ExecuteNonQuery();
                SQLiteDataReader dReader = comm.ExecuteReader();
                while (dReader.Read())
                {
                    id = dReader.GetInt32(0);
                    MessageBox.Show(id.ToString());
                    
                }
                sqlCon.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("dbExeption1 " + ex.Message);
            }
            return id;
        }


        
        //methode pour remplir le combobox des projet
        private void fillCombobox()
        {

            //ouverture de la connection à la base de donnée
            try
            {
                sqlCon.Open();
                string query = "Select project_name from project";
                //SQLiteCommand comm = new SQLiteCommand(query, sqlCon);
                //comm.ExecuteNonQuery();
                //SQLiteDataReader dReader = comm.ExecuteReader();
                SQLiteDataAdapter dba = new SQLiteDataAdapter(query, sqlCon);
                DataSet dSet = new DataSet();
                dba.Fill(dSet, "project");
                sqlCon.Close();
                DataTable dt = dSet.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    int i = 0;
                    foreach (DataColumn column in dt.Columns)
                    {
                        try
                        {
                            add_bug_prjctCB.Items.Add(row[i].ToString());
                            i++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("here" + ex.Message);
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
