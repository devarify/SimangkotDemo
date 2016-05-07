/* 
    Copyright (c) 2012 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
  
    To see all Code Samples for Windows Phone, visit http://go.microsoft.com/fwlink/?LinkID=219604 
  
*/
using System;
using System.Windows;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Controls;
using Simangkot.Resources;
using Microsoft.Phone.Maps;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location; // Provides the GeoCoordinate class.
using Windows.Devices.Geolocation; //Provides the Geocoordinate class.
using System.Windows.Shapes;
using System.Windows.Media;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Phone.Maps.Services;
using Microsoft.Phone.Maps.Toolkit;
using Microsoft.Phone.Tasks;
using Windows.Foundation;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace Simangkot
{

    public partial class MainPage : PhoneApplicationPage
    {
        
        // Constructor.

        GeoCoordinate currentLocation = new GeoCoordinate();
        public MainPage()
        {

            InitializeComponent();

            // Create the localized ApplicationBar.
            BuildLocalizedApplicationBar();

            GetLocation();
        }

        private async void GetLocation()
        {
            try
            {
                // Get current location.
                Geolocator myGeolocator = new Geolocator();
                Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
                Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
                currentLocation = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
            }
            catch(Exception)
            {
                if (MessageBox.Show("Aplikasi ini membutuhkan lokasi anda, apakah anda akan mengaktifkan lokasi ?", "Perhatian !", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    var ope = Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-location:"));
                }
                else
                {
                    //MessageBox.Show("Anda akan keluar dari aplikasi", "", MessageBoxButton.OK);
                    Application.Current.Terminate();
                }
            }
        }

        ///

        /// Event handler to intercept MainPage navigation
        ///
        /// the frame ///
        ///navigation args
        //void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        //{
        //    // Only care about MainPage
        //    if (e.Uri.ToString().Contains("/MainPage.xaml") != true)
        //    {
        //        return;
        //    }

        //    // Check if this is the first run of the application
        //    if ((bool)settings["firstRun"])
        //    {
        //        e.Cancel = true;
        //        RootFrame.Dispatcher.BeginInvoke(delegate
        //        {
        //            RootFrame.Navigate(new Uri("/FirstRun.xaml", UriKind.Relative));
        //            settings["firstRun"] = (bool)false;
        //        });
        //    }
        //    else
        //    {
        //        RootFrame.Dispatcher.BeginInvoke(delegate
        //        {
        //            RootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        //        });
        //    }
        //}
        



        private void Angkot1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Angkot1.xaml", UriKind.Relative));
        }

        private void Detail1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Detail1.xaml", UriKind.Relative));
        }




        // Create the localized ApplicationBar.
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Opacity = 0.5;

            // Create buttons with localized strings from AppResources.
            // Toggle Location button.

            ApplicationBarMenuItem MenuSetting = new ApplicationBarMenuItem();
            MenuSetting.Text = "Pengaturan";
            ApplicationBar.MenuItems.Add(MenuSetting);
            MenuSetting.Click += new EventHandler(Setting_Click);
            
            ApplicationBarMenuItem MenuBantuan = new ApplicationBarMenuItem();
            MenuBantuan.Text = "Bantuan";
            ApplicationBar.MenuItems.Add(MenuBantuan);
            MenuBantuan.Click += new EventHandler(Bantuan_Click);

            ApplicationBarMenuItem MenuAbout = new ApplicationBarMenuItem();
            MenuAbout.Text = "Tentang";
            ApplicationBar.MenuItems.Add(MenuAbout);
            MenuAbout.Click += new EventHandler(About_Click);

            ApplicationBarMenuItem MenuRate = new ApplicationBarMenuItem();
            MenuRate.Text = "Rate Aplikasi!";
            ApplicationBar.MenuItems.Add(MenuRate);
            MenuRate.Click += new EventHandler(Rate_Click);

            
        }

        private async void Setting_Click(object sender, EventArgs e)
        {
            var op = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-location:"));
        }

        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void Bantuan_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Bantuan.xaml", UriKind.Relative));
        }


        private void Angkot2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Angkot2.xaml", UriKind.Relative));
        }

        private void Detail2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Detail2.xaml", UriKind.Relative));
        }

        private void Detail3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Detail3.xaml", UriKind.Relative));
        }

        private void Angkot4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Angkot4.xaml", UriKind.Relative));
        }

        private void Angkot3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Angkot3.xaml", UriKind.Relative));
        }

        private void Detail4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Detail4.xaml", UriKind.Relative));
        }









        public void Rate_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask review = new MarketplaceReviewTask();
            review.Show();
        }

        

    }
}
