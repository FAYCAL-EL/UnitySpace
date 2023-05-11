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

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for Comfirmed_meeting.xaml
    /// </summary>
    public partial class Comfirmed_meeting : UserControl
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\User.mdf;Integrated Security=True");
        public Comfirmed_meeting()
        {
            InitializeComponent();

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select (idMeeting) from [meeting_member] where idMember='" + member_index.user.Id + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows) {
                ContentC.Content = new empty_meetings();
            }
            else
            {
                Console.WriteLine("hna khas ydar loop bach y tinstanci les meeting");
            }
        }
    }
}
