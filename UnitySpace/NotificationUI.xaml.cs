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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class NotificationUI : UserControl
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True");
        private int _id;
        public NotificationUI(int id)
        {
            InitializeComponent();
            _id = id;
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [meetings].title, sendDate, [User].Title, profil, isRead FROM [meetings], [meeting_member], [User] WHERE [meetings].meeting_id='" + id + "' AND [User].Id=meetings.chef AND [meeting_member].idMeeting ='" + id + "' AND [meeting_member].idMember ='" + member_index.user.Id + "'";
            /*"select (title,sendDate,chefTitle,profil,isRead) from [meetings],[meeting_member],[User] where meetings.meeting_id='" + id + "' and User.Id=meetings.chef and meeting_member.idMeeting ='"+id+"' and meeting_member.idMember ='"+member_index.user.Id+"'";*/
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                notificationTitle.Text = reader.GetString(0);
                notificationDate.Text =reader.GetDateTime(1).ToString();
                chefTitle.Text = reader.GetString(2) ;
                String imagePath = "Images/profiles/" + reader.GetString(3);
                int isRead = reader.GetInt32(4);
                chefImage.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                NotifisRead.Background = isRead==1 ? Brushes.Green : Brushes.Red;
            }

            connection.Close();
            
          

        }

       
            

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            
           member_index.popUp.IsOpen = false;
            member_index.popUpContent.Children.Clear();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE [meeting_member] SET isRead =1 where idMeeting='" + _id + "' and idMember='" + member_index.user.Id + "'";
            command.ExecuteNonQuery();
            connection.Close();
            member_index.home.Content = new showMeeting(_id);
        }
    }
}
