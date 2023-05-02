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
using MaterialDesignThemes;

using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True");
        public MainWindow()
        {

            InitializeComponent();
    
        }

        private Boolean Login(String email,String password) 
        {
            
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [User] where email='"+email+ "' and password='"+password+"'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;

            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Login(identifactionLabel.Text.ToString(), passwordLabel.Password))
            {
                Console.WriteLine("login succesfully");
            }
            else
            {

                notification.Content = "Identification or password incorrect";
                identifactionLabel.Text = "";
                passwordLabel.Password = "";
                
            }

        }
    }
}
