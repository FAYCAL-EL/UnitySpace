﻿using System;
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

using System.Data.SqlClient;
using System.Data;

namespace UnitySpace
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        private   void  Rbtn1_checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new CreateMeeting();
        }
        private void Rbtn2_checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UpcomingMeetings();
        }
    }
}
