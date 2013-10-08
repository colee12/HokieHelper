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
    public partial class DeanStudent : PhoneApplicationPage
    {
        public DeanStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                PhoneCallTask phoneTask = new PhoneCallTask();
                phoneTask.PhoneNumber = textBox1.Text;
                phoneTask.DisplayName = "Dean of Students Office";
                phoneTask.Show();
            }
            catch (System.Reflection.TargetInvocationException excep)
            {
                //System.Diagnostics
                throw (excep);
            }
        }
    }
}