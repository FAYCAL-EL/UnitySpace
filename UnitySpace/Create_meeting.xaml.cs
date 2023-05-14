using System;
using System.Collections;
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
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\User.mdf;Integrated Security=True");
        public static List<int> id_members = new List<int>();
        private String meetitle;
        private String meetdesc;
        DateTime? sdateday;
        DateTime? endateday;
        int sdatehour;
        int endatehour;
        int sdateminute;
        int endateminute;
        DateTime starting;
        DateTime ending;
        String room;
        String material;

        string error_message = "Values missing : ";
        int _is_error = 0;
        int _no_member = 0;
        int _id;
        int _id_member;

        public Create_meeting(int id)
        {
            _id = id;
            id_members.Clear();
            InitializeComponent();
            start_date.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1)));
            end_date.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1)));
            for (int i = 0; i < 60; i++)
            {
                endminutes.Items.Add(i);
                startminutes.Items.Add(i);
            }
            for (int i = 08; i < 18; i++)
            {
                starthour.Items.Add(i);
                endhour.Items.Add(i);

            }
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
            participantIcon icon = new participantIcon(Convert.ToInt32(memberId));
            participants_pic.Children.Add(icon);

            _id_member = Convert.ToInt32(memberId);
            id_members.Add(_id_member);
            _no_member = 0;
            members_error_pic.Visibility = Visibility.Hidden;
            members_error.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentControl cc = (ContentControl)Parent;
            cc.Content = new upcoming_meeting(_id);
        }

        private void Buttonparti_Click(object sender, RoutedEventArgs e)
        {
            ParticipantPopup.IsOpen = true;

        }
        private void close_popup(object sender, RoutedEventArgs e)
        {
            ParticipantPopup.IsOpen = false;

        }
        private void add_parts(object sender, RoutedEventArgs e)
        {
            ParticipantPopup.IsOpen = false;


        }
        private void Create(object sender, RoutedEventArgs e)
        {
            SqlConnection connection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\User.mdf;Integrated Security=True");
            int meetingId;
            connection1.Open();

            // checking title
            if (string.IsNullOrEmpty(meeting_title.Text))
            {
                error_message += "Titre,";
                meeting_title.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000"));
                _is_error++;
            }
            else
            {
                meetitle = meeting_title.Text;
            }
            // checking description if it's empty
            if (string.IsNullOrEmpty(description.Text))
            {

                error_message += " Discription,";
                description.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000"));
                _is_error++;
            }
            else
            {
                meetdesc = description.Text;
            }
            // checking date if it's empty
            if (start_date.SelectedDate.HasValue)
            {
                sdateday = start_date.SelectedDate;

            }
            else
            {
                error_message += " Starting Date,";
                start_date.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000"));
                _is_error++;
            }
            // checking hour and minutes if it's empty
            if (starthour.SelectedItem == null || startminutes.SelectedItem == null)
            {

                error_message += " starting Hour or minute,";
                starthour.BorderBrush = Brushes.Red;
                startminutes.BorderBrush = Brushes.Red;
                _is_error++;
            }
            else
            {
                sdatehour = int.Parse(starthour.SelectedItem.ToString());
                sdateminute = int.Parse(startminutes.SelectedItem.ToString());
            }

            // checking ending if it's empty
            if (end_date.SelectedDate.HasValue)
            {
                endateday = end_date.SelectedDate;
            }
            else
            {
                error_message += " Starting Date,";
                end_date.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000"));
                _is_error++;
            }
            //chacking ending minutes and hour 
            if (endhour.SelectedItem == null || endhour.SelectedItem == null)
            {

                error_message += " ending Hour or minute,";
                endhour.BorderBrush = Brushes.Red;
                endhour.BorderBrush = Brushes.Red;
                _is_error++;
            }
            else
            {
                endatehour = int.Parse(endhour.SelectedItem.ToString());
                endateminute = int.Parse(endminutes.SelectedItem.ToString());
            }
            //room or material is not empty
            if (Select_material.SelectedItem == null || select_room.SelectedItem == null)
            {

                error_message += " room or material";
                Select_material.BorderBrush = Brushes.Red;
                select_room.BorderBrush = Brushes.Red;
                _is_error++;
            }
            else
            {
                material = Select_material.SelectedItem.ToString();
                room = select_room.SelectedItem.ToString();
            }






            if (_is_error == 0)
            {
                error_pic.Visibility = Visibility.Hidden;
                error.Text = "";

                starting = new DateTime(sdateday.Value.Year, sdateday.Value.Month, sdateday.Value.Day, sdatehour, sdateminute, 0);
                ending = new DateTime(endateday.Value.Year, endateday.Value.Month, endateday.Value.Day, endatehour, endatehour, 0);

                if (id_members.Count == 0)
                {
                    members_error_pic.Visibility = Visibility.Visible;
                    members_error.Text = "Can't creat a meeting without members ";
                    _no_member++;
                    return;
                }

                if (starting.CompareTo(ending) >= 0)
                {
                    error_pic.Visibility = Visibility.Visible;
                    error.Text = "Ending time should not be earlier than the starting time ";

                    return;
                }

                string insertStatement = "INSERT INTO [meetings] (title, description, starting_date,ending_date, meeting_room, chef,meetinfg_material) VALUES (@Value1, @Value2, @Value3,@Value4, @Value5, @Value6,@Value7); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(insertStatement, connection1))
                {
                    command.Parameters.AddWithValue("@Value1", meetitle);
                    command.Parameters.AddWithValue("@Value2", meetdesc);
                    command.Parameters.AddWithValue("@Value3", starting);
                    command.Parameters.AddWithValue("@Value4", ending);
                    command.Parameters.AddWithValue("@Value5", room);
                    command.Parameters.AddWithValue("@Value6", _id);
                    command.Parameters.AddWithValue("@Value7", material);


                    meetingId = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("New employee ID: " + meetingId);
                }
                connection1.Close();


                DateTime now = DateTime.Now;

                foreach (int i in id_members)
                {
                    SqlConnection connection2 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\User.mdf;Integrated Security=True");
                    _no_member++;
                    string insertStatement1 = "INSERT INTO [meeting_member] (idMeeting, idMember, sendDate) VALUES (@Value1, @Value2, @Value3);";
                    using (connection2)
                    {
                        connection2.Open();

                        using (SqlCommand command = new SqlCommand(insertStatement1, connection2))
                        {
                            command.Parameters.AddWithValue("@Value1", meetingId);
                            command.Parameters.AddWithValue("@Value2", i);
                            command.Parameters.AddWithValue("@Value3", now);

                            int rowsAffected = command.ExecuteNonQuery();

                        }

                        connection2.Close();
                    }

                }
                Chef_Index.home.Content = new Show_Meeting_Chef(meetingId);
            }
            else
            {

                error_pic.Visibility = Visibility.Visible;
                error.Text = error_message;
                error_message = "Values missing : ";
                _is_error = 0;
                return;

            }


        }

    }
}
