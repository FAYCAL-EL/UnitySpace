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
using System.Windows.Shapes;

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for Chef_Index.xaml
    /// </summary>
    public partial class Chef_Index : Window
    {
        private User _user ;
        static public ContentControl home;

        static int numbOfNotif = 2;
        public Chef_Index(User user)
        {

            InitializeComponent();
            _user = user;
            string profile = user.Profil;
            string image_path = "Images/profiles/" + profile;
            profil.Source = new BitmapImage(new Uri(image_path, UriKind.Relative));
            home = CC;


            notifBullet.Text = numbOfNotif.ToString();
            notifBarCounter.Text = numbOfNotif.ToString() + " notification" + (numbOfNotif > 1 ? "s" : "");
            CC.Content = new meeting(_user.Id);
        }

        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            NotificationPopup.IsOpen = false;
        }

        private void ButtonNotif_Click(object sender, RoutedEventArgs e)
        {
            
            if (!NotificationPopup.IsOpen)
            {
              
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
            CC.Content = new Create_meeting(_user.Id);
        }
        private void upcoming_meeting(object sender, RoutedEventArgs e)
        {
            CC.Content = new upcoming_meeting(_user.Id);
        }
        private void meeting(object sender, RoutedEventArgs e)
        {
            CC.Content = new meeting(_user.Id);
        }
       
        private void logout(object sender, RoutedEventArgs e)
        {
            _user = null;
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }
    }
}
