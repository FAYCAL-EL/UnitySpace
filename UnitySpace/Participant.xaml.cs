using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Participants.xaml
    /// </summary>
    public partial class Participant : UserControl
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\User.mdf;Integrated Security=True");
        private int _id;
        public event EventHandler<string> MemberIdClicked;
        public Participant(int id)
        {
            
            string hexColor;

            InitializeComponent();
            _id = id;
            
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Nom,Prenom,Title,profil FROM [User] WHERE id = "+id;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Part_name.Text = reader.GetString(0) +" "+ reader.GetString(1);
                Part_Position.Text = reader.GetString(2);
                string profil_path = "Images/profiles/"+reader.GetString(3);
                profil.Source = new BitmapImage(new Uri(profil_path, UriKind.Relative));

            }
            
            
            particpate.Tag = id;

            available.Text = "available";
            if (available.Text == "available")
            {
                hexColor = "#0ACA85";
            }
            else
            {
                hexColor = "#FFCA0A0A";
            }
            Color color = (Color)ColorConverter.ConvertFromString(hexColor);
            SolidColorBrush brush = new SolidColorBrush(color);
            available.Foreground = brush;

            connection.Close();
        }
        
        public void Add_participant(object sender, RoutedEventArgs e)
        {
            part_button.IsEnabled = false;
            part_button.Background.Opacity = 0.4;
            string memberId = particpate.Tag.ToString();
            MemberIdClicked?.Invoke(this, memberId);
        }


    }
}
