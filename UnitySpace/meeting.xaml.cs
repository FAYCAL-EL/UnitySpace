using System;
using System.Collections.Generic;
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
    /// Interaction logic for meeting.xaml
    /// </summary>
    public partial class meeting : UserControl
    {
        public class Meeting
        {
            public string Title { get; set; }
            public int thisMeetid { get; set; }
        }
        private int _id;
        public meeting(int idChef)
        {

            _id = idChef;
            InitializeComponent();

            // Create a list to store the retrieved meetings

            List<Meeting> meetings = new List<Meeting>();

            // Create a new SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True"))
            {
                // Open the connection
                connection.Open();

                // Create a SQL query to retrieve meetings for the current chef ID
                DateTime now = DateTime.Now;
                string formattedNow = now.ToString("M/d/yyyy h:mm:ss tt");
                string query = "SELECT title, meeting_id FROM meetings WHERE chef = '" + _id + "' AND starting_date <= '" + formattedNow + "'";

                // Create a new SqlCommand with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and retrieve the data using a SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Create a list to store the retrieved meetings

                        // Read the data from the reader and create Meeting objects
                        while (reader.Read())
                        {
                            // Create a new Meeting object
                            Meeting meet = new Meeting();

                            // Set the properties of the Meeting object based on the retrieved data
                            meet.Title = reader.GetString(0);
                            meet.thisMeetid = reader.GetInt32(1);

                            // Add the Meeting object to the list
                            meetings.Add(meet);
                        }

                        // Now you have the list of meetings for the current chef ID
                        // You can use this list to dynamically create buttons or perform any other operations
                    }
                }
            }




            // Create a button for each meeting
            double y = 10;
            foreach (Meeting meet in meetings)
            {
                // Create a new button
                Button button = new Button();
                // Create a new SolidColorBrush with the desired color and opacity
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.Gray;
                brush.Opacity = 0.5;

                // Set the background of the button to the new SolidColorBrush
                button.Background = brush;

                // Set the properties of the button
                button.Height = 50;
                button.Width = 500;
                button.Margin = new Thickness(0, y, 0, 0);

                // Create a stack panel to hold the content of the button
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;

                // Add an image to the stack panel
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("Images/check-box.png", UriKind.Relative));
                image.Width = 18;
                stackPanel.Children.Add(image);

                // Add a label to the stack panel with the meeting title
                Label label = new Label();
                label.Foreground = Brushes.White;
                label.Margin = new Thickness(10, 0, 0, 0);
                label.Content = meet.Title;
                stackPanel.Children.Add(label);

                // Add an image to the stack panel to represent closing the meeting
                Image closeButton = new Image();
                closeButton.Source = new BitmapImage(new Uri("Images/exit (1).png", UriKind.Relative));
                closeButton.Width = 18;
                closeButton.Margin = new Thickness(300, 0, 0, 0);
                stackPanel.Children.Add(closeButton);

                // Set the content of the button to the stack panel
                button.Content = stackPanel;

                button.Click += (sender, e) =>
                {
                    this.Visibility = Visibility.Collapsed;
                    Console.WriteLine("11111");

                    Show_Meeting_Chef show1 = new Show_Meeting_Chef(meet.thisMeetid);
                    Chef_Index.home.Content = show1;

                };

                // Add the button to the grid
                StackPanel stackp = (StackPanel)grid.FindName("gridstack");
                gridstack.Children.Add(button);
                //y += button.Height + 10; // add 10 for spacing between buttons

            }
        }
    }
}
