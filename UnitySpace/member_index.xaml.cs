using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for member_index.xaml
    /// </summary>
    /// 
  

    public partial class member_index : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True");
        static public User user;
        static int count = 0;
        static public ContentControl home;
        static int numbOfNotif = 0;
        static public Popup popUp;
        public member_index(User userI)
        {
            InitializeComponent();
            user = userI;
            string profile = user.Profil;
            home = membreC;
            popUp = NotificationPopup;
            string image_path = "Images/profiles/" + profile;
            profil.Source = new BitmapImage(new Uri(image_path, UriKind.Relative));

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select (idMeeting) from [meeting_member] where idMember='"+user.Id+"'";
            SqlDataReader reader = cmd.ExecuteReader();

            /*numbOfNotif = reader.Cast<Object>().Count();*/
            notifBullet.Text = numbOfNotif.ToString();
            notifBarCounter.Text = numbOfNotif.ToString() + " notification" + (numbOfNotif > 1 ? "s" : "");

            while (reader.Read())
            {
                Console.WriteLine("hello");
                notifactionContent.Children.Add(new NotificationUI(reader.GetInt32(0)));
            }

            connection.Close();

        }


        public void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            popUp.IsOpen = false;
        }

        private void ButtonNotif_Click(object sender, RoutedEventArgs e)
        {

            if (!popUp.IsOpen)
            {
                NotificationPopup.DataContext = "You have a new notification!";
                NotificationPopup.HorizontalOffset = NotificationPopup.Width / 3;
                NotificationPopup.VerticalOffset = 10;
                popUp.IsOpen = true;

            }
            else
            {
                popUp.IsOpen = false;
            }


        }
        private void comfirmed_meeting(object sender, RoutedEventArgs e)
        {
            home.Content = new Comfirmed_meeting(count);
        }
        private void logout(object sender, RoutedEventArgs e)
        {
            user = null;
            MainWindow_LocationChanged(sender,e);
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }
    }
}
