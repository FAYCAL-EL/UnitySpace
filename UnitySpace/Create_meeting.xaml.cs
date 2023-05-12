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
using System.Windows.Controls.Primitives;
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
        public static List<int> id_members = new List<int>();
        private String meetitle;
        private String meetdesc;
        DateTime? sdate;
        DateTime? endate;
        String room;
        String material;

        int _id;
        int _id_member;

        public Create_meeting(int id)
        {
            _id = id;
            InitializeComponent();
            using (connection)
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string post = "member";
                cmd.CommandText = "SELECT Id FROM [User] WHERE Post = @Post";
                cmd.Parameters.AddWithValue("@Post", post);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Participant participant = new Participant(reader.GetInt32(0));
                    participants_box.Children.Add(participant);
                    participant.MemberIdClicked += ParticipateControl1_MemberIdClicked;
                }
                reader.Close();

                SqlCommand materialCmd = new SqlCommand("SELECT Nom FROM [materials]", connection);
                SqlDataReader materialReader = materialCmd.ExecuteReader();
                Select_material.Items.Clear();
                while (materialReader.Read())
                {
                    Select_material.Items.Add(materialReader.GetString(0));
                }
                materialReader.Close();

                SqlCommand roomCmd = new SqlCommand("SELECT Nom FROM [Room]", connection);
                SqlDataReader roomReader = roomCmd.ExecuteReader();
                select_room.Items.Clear();
                while (roomReader.Read())
                {
                    select_room.Items.Add(roomReader.GetString(0));
                }
                roomReader.Close();

                connection.Close();
            }


        }
        
        private void ParticipateControl1_MemberIdClicked(object sender, string memberId)
        {
            //Console.WriteLine(memberId);
            participantIcon icon = new participantIcon(Convert.ToInt32(memberId));
            participants_pic.Children.Add(icon);
            
            _id_member = Convert.ToInt32(memberId) ;
            id_members.Add(_id_member);
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
        private void Create(object sender, RoutedEventArgs e)
        {
            meetitle = meeting_title.Text;
            meetdesc = description.Text;

            sdate = start_date.SelectedDate;
            endate = end_date.SelectedDate;

            material = Select_material.SelectedItem.ToString();
            room = select_room.SelectedItem.ToString();

            DateTime now = DateTime.Now;

            foreach (int i in id_members)
            {
                Console.WriteLine(i);
            }
        }

    }
}
