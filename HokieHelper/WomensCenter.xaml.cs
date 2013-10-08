using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace HokieHelper
{
    public partial class WomensCenter : PhoneApplicationPage
    {
        public WomensCenter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask phoneTask = new PhoneCallTask();
            phoneTask.PhoneNumber = textBox1.Text;
            phoneTask.DisplayName = "Womens Health Center";
            phoneTask.Show();
        }
    }
}