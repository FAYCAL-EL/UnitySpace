using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Net.Mime.MediaTypeNames;

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for showMeeting.xaml
    /// </summary>
    public partial class showMeeting : UserControl
    {
        private int _id;
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True");
        public showMeeting(int id)
        {
            _id = id;
            InitializeComponent();

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT title,description ,starting_date,meeting_room FROM [meetings] WHERE [meetings].meeting_id='" + id + "'";
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                meetingTitle.Text=reader.GetString(0);
                meetingDescription.Text = reader.GetString(1);
                meetingDate.Text = reader.GetDateTime(2).ToString();
                meetingPlace.Text = "Room N°15 4th Floor, National Labrary, Rabat ,Agdal , Morocco ";
                    /*reader.GetString(3);*/
            }

            reader.Close();
            SqlCommand cmdM = connection.CreateCommand();
            cmdM.CommandType = CommandType.Text;
            cmdM.CommandText = "SELECT idMember FROM [meeting_member] WHERE [meeting_member].idMeeting='" + id + "'";
            SqlDataReader readerM = cmdM.ExecuteReader();

            while (readerM.Read())
            {
                participants.Children.Add(new participantIcon(readerM.GetInt32(0)));
            }



            connection.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            member_index.popUp.IsOpen = false;
            member_index.home.Content = new Comfirmed_meeting();
        }

        private void confirm_btn(object sender, RoutedEventArgs e)
        {
      
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE [meeting_member] SET isComfirmed = 'true' where idMeeting='" + _id + "' and idMember='" + member_index.user.Id + "'";
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("yes");
            }

            connection.Close();


            member_index.home.Content = new Comfirmed_meeting();
        }

        private void cancel_btn(object sender, RoutedEventArgs e)
        {
            
            member_index.home.Content = new Comfirmed_meeting();
        }


    }
}
