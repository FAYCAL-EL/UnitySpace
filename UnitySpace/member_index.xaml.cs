using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for member_index.xaml
    /// </summary>
    /// 
  

    public partial class member_index : Window
    {
        private User _user;
        public int count = 0;
        
        static int numbOfNotif = 2;
        public member_index(User user)
        {
            InitializeComponent();
            _user = user;
            string profile = user.Profil;
            string image_path = "Images/profiles/" + profile;
            profil.Source = new BitmapImage(new Uri(image_path, UriKind.Relative));
            notifBullet.Text = numbOfNotif.ToString();
            notifBarCounter.Text = numbOfNotif.ToString() + " notification" + (numbOfNotif > 1 ? "s" : "");
            String imagePath = @"Images/profiles/faycal.jpg";
            String title = "RH MEETING  : new RH strategie";
            String chefT = "Chef RH Team";
            String date = "22-10-2023 08:52";
            NotificationUI ui = new NotificationUI(title, imagePath, chefT, date, true);
            notifactionContent.Children.Add(ui);

            String imagePath1 = @"Images/profiles/youssef.jpg";
            String title1 = "RH MEETING  : new RH strategie";
            String chefT1 = "Chef RH Team";
            String date1 = "22-10-2023 08:52";
            NotificationUI ui1 = new NotificationUI(title1, imagePath1, chefT1, date1, false);
            notifactionContent.Children.Add(ui1);

        }


        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            NotificationPopup.IsOpen = false;
        }

        private void ButtonNotif_Click(object sender, RoutedEventArgs e)
        {

            if (!NotificationPopup.IsOpen)
            {
                NotificationPopup.DataContext = "You have a new notification!";
                NotificationPopup.HorizontalOffset = NotificationPopup.Width / 3;
                NotificationPopup.VerticalOffset = 10;
                NotificationPopup.IsOpen = true;

            }
            else
            {
                NotificationPopup.IsOpen = false;
            }


        }
        private void comfirmed_meeting(object sender, RoutedEventArgs e)
        {
            membreC.Content = new Comfirmed_meeting(count);
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
