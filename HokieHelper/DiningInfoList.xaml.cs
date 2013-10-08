using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text.RegularExpressions;
using SQLite;

namespace HokieHelper
{
    public partial class DiningInfoList : PhoneApplicationPage
    {

        String hall;
        String today;
        SQLiteAsyncConnection conn;
        SQLiteAsyncConnection menuconn;
        String[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        List<DiningHours> vendorList = new List<DiningHours>();
        List<NutritionItems> menuList = new List<NutritionItems>();


        public DiningInfoList()
        {
            InitializeComponent();
            // Load the Dining Hall that was saved into Current.State from Dining.xaml.cs
            this.hall = PhoneApplicationService.Current.State["hall"].ToString();
            diningTitle.Title = hall;
            System.Diagnostics.Debug.WriteLine(hall);
            this.today = DateTime.Now.DayOfWeek.ToString();
            daypicker.ItemsSource = daysOfWeek;
            daypicker.SelectedItem = DateTime.Now.DayOfWeek.ToString();
            Query();
            //MenuQuery();
        }

        public async void Query()
        {
            this.conn = new SQLiteAsyncConnection("DiningHours.rdb");
            var query = conn.Table<DiningHours>().Where(x => x.Building == hall);
            var result = await query.ToListAsync();
          
            foreach (var item in result)
            {
                placepicker.Items.Add(item.Vendor);
                this.vendorList.Add(item);
            }
            Fill_Hours(result[0]);
        }

        public async void MenuQuery()
        {
            this.menuconn = new SQLiteAsyncConnection("nutrition.db");
            var menuquery = menuconn.Table<NutritionItems>().Where(x => x.Location == "d2");
            var result = await menuquery.ToListAsync();

            foreach (var item in result)
            {
                this.menuList.Add(item);
            }
            List<AlphaKeyGroup<NutritionItems>> DataSource = AlphaKeyGroup<NutritionItems>.CreateGroups(menuList,
                System.Threading.Thread.CurrentThread.CurrentUICulture,
                (NutritionItems s) => { return s.Name; }, true);
            MenuList.ItemsSource = DataSource;
        }

        private void hall_change(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            foreach (var item in vendorList)
            {
                if (item.Vendor.ToString() == placepicker.SelectedItem as String)
                {
                    Fill_Hours(item);
                }
            }
        }

        private void Fill_Hours(DiningHours obj)
        {
            String day = daypicker.SelectedItem.ToString();

            switch (day)
            {
                case "Monday":
                    hours.Text = obj.Monday;
                    break;
                case "Tuesday":
                    hours.Text = obj.Tuesday;
                    break;
                case "Wednesday":
                    hours.Text = obj.Wednesday;
                    break;
                case "Thursday":
                    hours.Text = obj.Thursday;
                    break;
                case "Friday":
                    hours.Text = obj.Friday;
                    break;
                case "Saturday":
                    hours.Text = obj.Saturday;
                    break;
                case "Sunday":
                    hours.Text = obj.Sunday;
                    break;
                default:
                    hours.Text = "No Dining Hours Available";
                    break;
            }
        }

        private void day_changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("\nDay Changed\n");
            //var query = conn.Table<DiningHours>().Where(x => x.Building == hall);
            //var result = await query.ToListAsync();
            //Fill_Hours(result[0]);
            foreach (var item in vendorList)
            {
                if (item.Vendor.ToString() == placepicker.SelectedItem as String)
                {
                    Fill_Hours(item);
                }
            }
        }
    }
}