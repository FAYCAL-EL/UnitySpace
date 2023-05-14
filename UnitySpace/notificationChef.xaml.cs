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
    /// Interaction logic for notificationChef.xaml
    /// </summary>
    public partial class notificationChef : UserControl
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\User.mdf;Integrated Security=True");
        private int _idMbr,_idMe;
        public notificationChef(int idMbr, int idMe)
        {
            InitializeComponent();

            _idMe = idMe;
            _idMbr= idMbr;
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  [User].Nom,[User].Prenom,profil, justification FROM [meeting_member], [User] WHERE [meeting_member].idMeeting='" + idMe + "' AND [User].Id=[meeting_member].idMember AND [meeting_member].idMember ='" + idMbr + "'";

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                chefTitle.Text = reader.GetString(0) + " " + reader.GetString(1);

                notificationTitle.Text = reader.GetString(3);
                String imagePath = "Images/profiles/" + reader.GetString(2);

                chefImage.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));

            }

            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Chef_Index.popUp.IsOpen = false;
            
            Chef_Index.home.Content = new showAbsent(_idMbr, _idMe);
        }
    }
}
