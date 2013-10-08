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
    public partial class Schiffert : PhoneApplicationPage
    {
        public Schiffert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine("here\n");
            try
            {
                PhoneCallTask phoneTask = new PhoneCallTask();
                phoneTask.PhoneNumber = "540231644";
                phoneTask.DisplayName = "Schiffert Health Center";
                phoneTask.Show();
            }
            catch (System.Net.WebException excep)
            {
                //System.Diagnostics
                throw (excep);
            }
        }
    }
}