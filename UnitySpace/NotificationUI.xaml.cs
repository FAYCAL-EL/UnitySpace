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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class NotificationUI : UserControl
    {
        public NotificationUI(String title, String imagePath, String chefName, String time, bool isRead)
        {
            InitializeComponent();
            chefImage.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            chefTitle.Text = chefName;
            notificationDate.Text = time;
            notificationTitle.Text = title;
            NotifisRead.Background = isRead ? Brushes.Green : Brushes.Red;

        }
    }
}
