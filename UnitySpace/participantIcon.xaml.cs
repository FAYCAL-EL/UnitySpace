using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for participantIcon.xaml
    /// </summary>
    public partial class participantIcon : UserControl
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True");
        public participantIcon(int id)
        {
            InitializeComponent();
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT profil FROM [User] WHERE [User].Id='" + id + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string imagePath = "Images/profiles/" + reader.GetString(0);
                participant.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));

            }
        }
    }
}
