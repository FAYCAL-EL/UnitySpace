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
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for Chef_Index.xaml
    /// </summary>
    public partial class Chef_Index : Window
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\User.mdf;Integrated Security=True");
        static public User _user ;
        static public ContentControl home;
        static public StackPanel popUpContent;
        static public Popup popUp;
        static int numbOfNotif = 0;
        public Chef_Index(User user)
        {

            InitializeComponent();
            _user = user;
            string profile = user.Profil;
            string image_path = "Images/profiles/" + profile;
            profil.Source = new BitmapImage(new Uri(image_path, UriKind.Relative));
            home = CC;
            popUp = NotificationPopup;
            popUpContent = notifactionContent;

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(*) from [meeting_member],[meetings] where isComfirmed='false' and idMeeting=meeting_id and chef='" + _user.Id + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                numbOfNotif = reader.GetInt32(0);
            }
            reader.Close();
            connection.Close();
            notifBullet.Text = numbOfNotif.ToString();
            notifBarCounter.Text = numbOfNotif.ToString() + " notification" + (numbOfNotif > 1 ? "s" : "");
            CC.Content = new meeting(_user.Id);
        }


        private void fetcheingDataIntoPopUp()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select idMember,idMeeting from [meeting_member],[meetings] where isComfirmed='false' and idMeeting=meeting_id and chef='" + _user.Id + "'";
            SqlDataReader reader = cmd.ExecuteReader();

            /*numbOfNotif = reader.Cast<Object>().Count();*/
            notifBullet.Text = numbOfNotif.ToString();
            notifBarCounter.Text = numbOfNotif.ToString() + " notification" + (numbOfNotif > 1 ? "s" : "");

            while (reader.Read())
            {
           
                popUpContent.Children.Add(new notificationChef(reader.GetInt32(0), reader.GetInt32(1)));
            }

            connection.Close();
        }



        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            NotificationPopup.IsOpen = false;
            

        }

        private void ButtonNotif_Click(object sender, RoutedEventArgs e)
        {
            
            if (!NotificationPopup.IsOpen)
            {
                popUpContent.Children.Clear();
                fetcheingDataIntoPopUp();
                NotificationPopup.HorizontalOffset = NotificationPopup.Width / 3;
                NotificationPopup.VerticalOffset = 10;
                NotificationPopup.IsOpen = true;

            }
            else
            {
                NotificationPopup.IsOpen = false;
                
            }


        }


        private void create_meeting(object sender, RoutedEventArgs e)
        {
            MainWindow_LocationChanged(sender, e);
            CC.Content = new Create_meeting(_user.Id);
        }
        private void upcoming_meeting(object sender, RoutedEventArgs e)
        {
            MainWindow_LocationChanged(sender, e);
            CC.Content = new upcoming_meeting(_user.Id);
        }
        private void meeting(object sender, RoutedEventArgs e)
        {
            MainWindow_LocationChanged(sender, e);
            CC.Content = new meeting(_user.Id);
        }
       
        private void logout(object sender, RoutedEventArgs e)
        {
            MainWindow_LocationChanged(sender, e);
            _user = null;
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }
    }
}
