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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Security.Cryptography;


namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for Show_Meeting_Chef.xaml
    /// </summary>
    /// 


    public class DateTimeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime < DateTime.Now ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }




    public partial class Show_Meeting_Chef : UserControl
    {
        private int _id;
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\User.mdf;Integrated Security=True");

        public string AttachedFilePath { get; set; }

        public Show_Meeting_Chef(int id)
        {

            _id = id;
            InitializeComponent();

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT title, description, starting_date, meeting_room, FileName FROM [meetings] LEFT JOIN [AttachedFiles] ON [meetings].meeting_id = [AttachedFiles].MeetingId WHERE [meetings].meeting_id = '" + _id + "'";
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    meetingTitle.Text = reader.GetString(0);
                    meetingDescription.Text = reader.GetString(1);
                    meetingDate.Text = reader.GetDateTime(2).ToString();
                    meetingPlace.Text = reader.GetString(3);

                    if (!reader.IsDBNull(4))
                    {
                        AttachmentMessage.Text = $"File {reader.GetString(4)} attached.";
                    }
                    else
                    {
                        AttachmentMessage.Text = "No file attached.";
                    }
                }
            }


            reader.Close();
            SqlCommand cmdM = connection.CreateCommand();
            cmdM.CommandType = CommandType.Text;
            cmdM.CommandText = "SELECT idMember FROM [meeting_member] WHERE [meeting_member].idMeeting='" + _id + "'";
            SqlDataReader readerM = cmdM.ExecuteReader();

            while (readerM.Read())
            {
                participants.Children.Add(new participantIcon(readerM.GetInt32(0)));
            }




            connection.Close();
        }


        public DateTime MeetingStartingDate
        {
            get
            {

                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\User.mdf;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT starting_date FROM [meetings] WHERE meeting_id = @id", connection);
                    command.Parameters.AddWithValue("@id", _id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetDateTime(0);
                    }
                    else
                    {
                        throw new ArgumentException($"No meeting found with id {_id}");
                    }
                }
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentControl cc = (ContentControl)Parent;
            cc.Content = new upcoming_meeting(_id);
        }




        private void AttachButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "PDF Files (*.pdf)|*.pdf";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filePath = dlg.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                string fileExtension = System.IO.Path.GetExtension(filePath);

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True"))
                {
                    string query = "INSERT INTO AttachedFiles(MeetingId, FileName, FilePath) VALUES (@MeetingId, @FileName, @FilePath); SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@MeetingId", _id);
                        cmd.Parameters.AddWithValue("@FileName", fileName);
                        cmd.Parameters.AddWithValue("@FilePath", filePath);
                        con.Open();
                        int fileId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }

                }
                // Show the message in the text block
                AttachmentMessage.Text = $"File {fileName} attached.";
                DownloadMessaage.Text = "";

            }
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True"))
            {
                string query = "SELECT FilePath FROM [AttachedFiles] WHERE MeetingId = '" + _id + "'";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MeetingId", _id);
                    con.Open();
                    string filePath = Convert.ToString(cmd.ExecuteScalar());
                    con.Close();

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                        dlg.FileName = System.IO.Path.GetFileName(filePath);
                        dlg.DefaultExt = System.IO.Path.GetExtension(filePath);
                        dlg.Filter = "PDF Files (*.pdf)|*.pdf";

                        Nullable<bool> result = dlg.ShowDialog();

                        if (result == true)
                        {
                            string downloadFilePath = dlg.FileName;
                            System.IO.File.Copy(filePath, downloadFilePath, true);
                        }
                        DownloadMessaage.Text = "Successfully Downloaded";

                    }
                    else
                    {
                        DownloadMessaage.Text = "No report available!";     
                    }
                }
            }
        }



    }
}
