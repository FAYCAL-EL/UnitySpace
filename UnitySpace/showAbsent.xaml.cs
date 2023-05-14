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
    /// Interaction logic for showAbsent.xaml
    /// </summary>
    public partial class showAbsent : UserControl
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\User.mdf;Integrated Security=True");
        public showAbsent(int idMbr,int idMe)
        {
            InitializeComponent();
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT profil,Nom,Prenom,justification,[meetings].title FROM [User],[meetings],[meeting_member] WHERE [User].Id='" + idMbr + "' and [meetings].meeting_id='"+idMe+"' and [meeting_member].idMember='"+idMbr+"' and [meeting_member].idMeeting='"+idMe+"'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string imagePath = "Images/profiles/" + reader.GetString(0);
                participant.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                fullName.Text = reader.GetString(1)+" "+ reader.GetString(2);
                AbsenceReason.Text = reader.GetString(3);
                meetingTitle.Text = reader.GetString(4);



            }
            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Chef_Index.popUp.IsOpen = false;
            Chef_Index.home.Content = new upcoming_meeting(Chef_Index._user.Id);
        }
    }
}
