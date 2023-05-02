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
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True");
        public MainWindow()
        {

            InitializeComponent();
    
        }

        private User Login(String email,String password) 
        {
            User user;
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [User] where email='"+email+ "' and password='"+password+"'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nom =reader.GetString(1);
                string prenom = reader.GetString(2);
                string mail  = reader.GetString(3);
                string post =   reader.GetString(5);
                string pwd =    reader.GetString(4);
                string profil = reader.GetString(6);
                user = new User(id,nom,prenom,pwd,mail,post,profil);
                connection.Close();
                
            }
            else
            {
                user = null;
                connection.Close();

            }
            return user;



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = Login(identifactionLabel.Text.ToString(), passwordLabel.Password);
            if ( user != null)
            {
                if (user.Post.Equals("chef"))
                {
                    Chef_Index ci = new Chef_Index(user);
                    ci.Show();
                    this.Hide();
                }
                else
                {
                    member_index mi = new member_index(user);
                    mi.Show();
                    this.Hide();
                }
                
            }
            else
            {

                notification.Content = "Identification or password incorrect";
                notifpic.Visibility = Visibility.Visible;
                identifactionLabel.Text = "";
                passwordLabel.Password = "";
                
            }

        }
    }
}
