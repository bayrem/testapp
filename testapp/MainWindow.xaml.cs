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
                //déclaration du chemin de la base de donnée 
                string dbConnectionString = @"Data source=database.db;Version=3;";
                SQLiteConnection sqlCon = new SQLiteConnection(dbConnectionString);
                //ouverture de la connection à la base de donnée
                try
                {
                    sqlCon.Open();
                    string query = "Select * from user where name = '" + usernameTB.Text+"'";
                    SQLiteCommand comm = new SQLiteCommand(query, sqlCon);
                    comm.ExecuteNonQuery();
                    SQLiteDataReader dReader = comm.ExecuteReader();
                    
                    while(dReader.Read())
                    {
                            User.Id = dReader.GetInt32(0);
                            User.name = dReader.GetString(1);
                            User.last_name = dReader.GetString(2);
                            User.password = dReader.GetString(3);
                            User.position = dReader.GetString(4);
                            //MessageBox.Show(User.name+User.Id+User.last_name+User.password+User.position);
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("dbExeption"+ex.Message);
                }


                
                if (usernameTB.Text.Equals(User.name)  && PasswordBoxPB.Password.Equals(User.password))
                {
                    var newWindow = new Window1();
                    newWindow.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Wrong Password");
                
            }
            else
                MessageBox.Show("Wrong Info"); 
        }
    }
}
