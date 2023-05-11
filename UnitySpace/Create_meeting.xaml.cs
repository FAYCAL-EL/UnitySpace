using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using UnitySpace;

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for Create_meeting.xaml
    /// </summary>
    public partial class Create_meeting : UserControl
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True");
        List<int> pics = new List<int>();

        public Create_meeting()
        {
            InitializeComponent();
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string post = "member";
            cmd.CommandText = "SELECT (Id) FROM [User] WHERE Post = @Post";
            cmd.Parameters.AddWithValue("@Post", post);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Participant part = new Participant(reader.GetInt32(0));
                participants_box.Children.Add(part);

            }

            connection.Close();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Buttonparti_Click(object sender, RoutedEventArgs e)
        {
            ParticipantPopup.IsOpen = true;
        }
        private void close_popup(object sender, RoutedEventArgs e)
        {
            ParticipantPopup.IsOpen = false;
        }
        private void add_parts(object sender,RoutedEventArgs e)
        {
            ParticipantPopup.IsOpen = false;

        }

    }
}
