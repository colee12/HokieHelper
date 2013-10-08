using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLite;

namespace HokieHelper
{
    public partial class Dining : PhoneApplicationPage
    {
        public Dining()
        {
            InitializeComponent();

            DateTime now = DateTime.Now; // Use to Display Open or Close for a Dining Hall
        }

        public async void TurnerPlace_Click(object sender, RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["hall"] = "Turner Place"; // Save "Turner Place" into Current.State
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("DiningHours.rdb");
            var query = conn.Table<DiningHours>().Where(x => x.Building == "Turner Place");
            var result = await query.ToListAsync();
            /*foreach (var item in result)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0}: Monday - {1}", item.Vendor, item.Monday));
            }*/

            NavigationService.Navigate(new Uri("/DiningInfoList.xaml", UriKind.Relative)); // Navigate to the DiningInfo Page
        }

        public async void WestEnd_Click(object sender, RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["hall"] = "West End Market";
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("DiningHours.rdb");
            var query = conn.Table<DiningHours>().Where(x => x.Building == "West End Market");
            var result = await query.ToListAsync();
            NavigationService.Navigate(new Uri("/DiningInfoList.xaml", UriKind.Relative));
        }

        public async void HokieGrill_Click(object sender, RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["hall"] = "Hokie Grill";
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("DiningHours.rdb");
            var query = conn.Table<DiningHours>().Where(x => x.Building == "Hokie Grill");
            var result = await query.ToListAsync();
            NavigationService.Navigate(new Uri("/DiningInfoList.xaml", UriKind.Relative));
        }

        public async void Dietrick_Click(object sender, RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["hall"] = "Dietrick Hall";
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("DiningHours.rdb");
            var query = conn.Table<DiningHours>().Where(x => x.Building == "Dietrick Hall");
            var result = await query.ToListAsync();
            NavigationService.Navigate(new Uri("/DiningInfoList.xaml", UriKind.Relative));
        }

        private async void Owens_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["hall"] = "Owen's Food Court";
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("DiningHours.rdb");
            var query = conn.Table<DiningHours>().Where(x => x.Building == "Owen's Food Court");
            var result = await query.ToListAsync();
            NavigationService.Navigate(new Uri("/DiningInfoList.xaml", UriKind.Relative));
        }

        private async void Squires_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["hall"] = "Squires";
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("DiningHours.rdb");
            var query = conn.Table<DiningHours>().Where(x => x.Building == "Squires");
            var result = await query.ToListAsync();
            NavigationService.Navigate(new Uri("/DiningInfoList.xaml", UriKind.Relative));
        }

        private async void GLC_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["hall"] = "GLC";
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("DiningHours.rdb");
            var query = conn.Table<DiningHours>().Where(x => x.Building == "GLC");
            var result = await query.ToListAsync();
            NavigationService.Navigate(new Uri("/DiningInfoList.xaml", UriKind.Relative));
        }

        private async void VetMedClick(object sender, System.Windows.RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["hall"] = "Vet Med Cafe";
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("DiningHours.rdb");
            var query = conn.Table<DiningHours>().Where(x => x.Building == "Vet Med Cafe");
            var result = await query.ToListAsync();
            NavigationService.Navigate(new Uri("/DiningInfoList.xaml", UriKind.Relative));
        }
    }
}