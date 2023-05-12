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
    /// Interaction logic for Absent.xaml
    /// </summary>
    public partial class Absent : UserControl
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\User.mdf;Integrated Security=True");
        private int _id;
        public Absent(int id)
        {
            InitializeComponent();
            _id = id;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE [meeting_member] SET isComfirmed = 'false',justification='" + justif.Text + "' where idMeeting='" + _id + "' and idMember='" + member_index.user.Id + "'";
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("yes");
            }

            connection.Close();


            member_index.home.Content = new Comfirmed_meeting(member_index.user.Id);
        }
    }
}
