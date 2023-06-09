﻿using System;
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

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT title, description FROM [meetings] WHERE [meetings].meeting_id = '" + _id + "'";
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                meeting_title.Text = reader.GetString(0);
                meeting_desc.Text = reader.GetString(1);
            }

            connection.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(justif.Text))
            {
                error_justif.Text = "Justification field can not be empty !";
                justif.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000"));
            }
            else
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE [meeting_member] SET isComfirmed = 'false',justification='" + justif.Text + "' where idMeeting='" + _id + "' and idMember='" + member_index.user.Id + "'";
                int rowsAffected = command.ExecuteNonQuery();

                connection.Close();


                member_index.home.Content = new Comfirmed_meeting(member_index.user.Id);
            }
           
        }
    }
}
