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
        public int count = 1;
        public member_index(User user)
        {
            InitializeComponent();
            _user = user;
            string profile = user.Profil;
            string image_path = "Images/profiles/" + profile;
            profil.Source = new BitmapImage(new Uri(image_path, UriKind.Relative));
            

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
