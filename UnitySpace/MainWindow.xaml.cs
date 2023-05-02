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

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ysf\study\ci\ci2\S8\DotNet\projet\UnitySpace\UnitySpace\User.mdf;Integrated Security=True");
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

            /*int count =  cmd.ExecuteNonQuery();*/
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            nameLabel.Content = reader.GetString(1).ToString();



            connection.Close();

            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login(identifactionLabel.Text.ToString(), passwordLabel.Password);
        }
    }
}
