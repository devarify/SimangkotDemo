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


namespace Simangkot
{

    

    public partial class Angkot4 : PhoneApplicationPage
    {
        readonly MapsViewModel mainViewModel = new MapsViewModel();

        const int MIN_ZOOM_LEVEL = 1;
        const int MAX_ZOOM_LEVEL = 20;
        const int MIN_ZOOMLEVEL_FOR_LANDMARKS = 16;

        ToggleStatus locationToggleStatus = ToggleStatus.ToggledOff;

        GeoCoordinate currentLocation = new GeoCoordinate();
        MapLayer locationLayer = null;
        MapPolyline polyline = null;

        // Constructor.
        public Angkot4()
        {

            InitializeComponent();

            // Create the localized ApplicationBar.
            BuildLocalizedApplicationBar();

            // Get current location.
            GetLocation();

            this.MapExtensionsSetup(this.sampleMap1);

            this.DataContext = this.mainViewModel;

            HideStoresIconMenuItem = (ApplicationBarMenuItem)ApplicationBar.MenuItems[0];
            ShowStoresIconMenuItem = (ApplicationBarMenuItem)ApplicationBar.MenuItems[1];

            
            this.Loaded += this.sampleMap_Loaded;
            this.ShowStores(true);

            polyline = null;
            polyline = new MapPolyline();
            polyline.StrokeColor = Color.FromArgb(0xff, 0x00, 0x00, 0xff);
            polyline.StrokeThickness = 10;

            polyline.Path = new GeoCoordinateCollection() { 
new GeoCoordinate(-6.887563 , 107.567920),
new GeoCoordinate(-6.88773 , 107.568399),
new GeoCoordinate(-6.888658 , 107.567984),
new GeoCoordinate(-6.888404 , 107.567523),
new GeoCoordinate(-6.887563 , 107.567920),
new GeoCoordinate(-6.887419 , 107.567262),
//new GeoCoordinate(-6.891664 , 107.575521),
new GeoCoordinate(-6.889291 , 107.566699),
new GeoCoordinate(-6.889595 , 107.569394),
new GeoCoordinate(-6.890091 , 107.5718),
new GeoCoordinate(-6.890252 , 107.572101),
new GeoCoordinate(-6.893578 , 107.572621),
new GeoCoordinate(-6.89383 , 107.574376),
new GeoCoordinate(-6.891432 , 107.575565),
new GeoCoordinate(-6.891088 , 107.576108),
new GeoCoordinate(-6.891548 , 107.578804),
new GeoCoordinate(-6.89243 , 107.580931),
new GeoCoordinate(-6.892231 , 107.581102),
new GeoCoordinate(-6.892379 , 107.581856),
new GeoCoordinate(-6.892371 , 107.584058),
new GeoCoordinate(-6.892667 , 107.585034),
new GeoCoordinate(-6.895820 , 107.589542),
new GeoCoordinate(-6.898041 , 107.593242),
new GeoCoordinate(-6.898149 , 107.593619),
new GeoCoordinate(-6.899944 , 107.595615),
new GeoCoordinate(-6.900208 , 107.59712),
new GeoCoordinate(-6.900245 , 107.598211),
new GeoCoordinate(-6.900331 , 107.598229),
new GeoCoordinate(-6.900331 , 107.598557),
new GeoCoordinate(-6.90112 , 107.598558),
new GeoCoordinate(-6.901227 , 107.598419),
new GeoCoordinate(-6.90399 , 107.598381),
new GeoCoordinate(-6.903909 , 107.600929),
new GeoCoordinate(-6.903679 , 107.601069),
new GeoCoordinate(-6.903679 , 107.601369),
new GeoCoordinate(-6.90392 , 107.601498),
new GeoCoordinate(-6.903954 , 107.602228),
new GeoCoordinate(-6.904258 , 107.602538),
new GeoCoordinate(-6.904242 , 107.602952),
new GeoCoordinate(-6.90436 , 107.60345),
new GeoCoordinate(-6.904230 , 107.605007),
new GeoCoordinate(-6.903975 , 107.605658),
new GeoCoordinate(-6.904115 , 107.606239),
new GeoCoordinate(-6.904859 , 107.607206),
new GeoCoordinate(-6.906297 , 107.607753),
new GeoCoordinate(-6.906538 , 107.607978),
new GeoCoordinate(-6.906801 , 107.609292),
new GeoCoordinate(-6.909054 , 107.609416),
new GeoCoordinate(-6.90915 , 107.60852),
new GeoCoordinate(-6.90907 , 107.608171),
new GeoCoordinate(-6.907878 , 107.607586),
new GeoCoordinate(-6.907596 , 107.607249),
new GeoCoordinate(-6.907213 , 107.606391),
new GeoCoordinate(-6.907128 , 107.604459),
new GeoCoordinate(-6.908694 , 107.604459),
new GeoCoordinate(-6.909620 , 107.604202),
new GeoCoordinate(-6.91267 , 107.603949),
new GeoCoordinate(-6.912336 , 107.598301),
new GeoCoordinate(-6.912568 , 107.598),
//new GeoCoordinate(-6.912462 , 107.600283),
new GeoCoordinate(-6.916312 , 107.598209),
new GeoCoordinate(-6.916189 , 107.602201),
new GeoCoordinate(-6.91584 , 107.604491),
new GeoCoordinate(-6.914778 , 107.604572),
new GeoCoordinate(-6.914949 , 107.606412),
new GeoCoordinate(-6.915268 , 107.606969),
new GeoCoordinate(-6.914402 , 107.607163),
new GeoCoordinate(-6.913977 , 107.608076),
new GeoCoordinate(-6.913924 , 107.608999),
new GeoCoordinate(-6.910772 , 107.609066),
new GeoCoordinate(-6.90907 , 107.608171),
new GeoCoordinate(-6.907856 , 107.607571),
new GeoCoordinate(-6.907648 , 107.607372),
new GeoCoordinate(-6.907204 , 107.606416),
new GeoCoordinate(-6.907128 , 107.604459),
new GeoCoordinate(-6.904304, 107.604367),
//new GeoCoordinate(-6.914402 , 107.607163),
new GeoCoordinate(-6.904451 , 107.602528),
new GeoCoordinate(-6.904853 , 107.602103),
new GeoCoordinate(-6.904859 , 107.601439),
new GeoCoordinate(-6.903909 , 107.60131),
new GeoCoordinate(-6.903759 , 107.601053),
new GeoCoordinate(-6.903518 , 107.600983),
new GeoCoordinate(-6.901263 , 107.598489),
new GeoCoordinate(-6.901146 , 107.598251),
new GeoCoordinate(-6.900219 , 107.59822)
                    
                        };
            sampleMap1.MapElements.Add(polyline);
        }




        private MapMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the route displayed in the map
        /// </summary>
        private MapRoute MapRoute { get; set; }

        /// <summary>
        /// Gets or sets the application bar menu item used to hide the stores displayed in the map
        /// </summary>
        private ApplicationBarMenuItem HideStoresIconMenuItem { get; set; }

        /// <summary>
        /// Gets or sets the application bar menu item used to show the stores displayed in the map
        /// </summary>
        private ApplicationBarMenuItem ShowStoresIconMenuItem { get; set; }

        // Placeholder code to contain the ApplicationID and AuthenticationToken
        // that must be obtained online from the Windows Phone Dev Center
        // before publishing an app that uses the Map control.
        private void sampleMap_Loaded(object sender, RoutedEventArgs e)
        {
            MapsSettings.ApplicationContext.ApplicationId = "11f9b9c3-4164-4d0f-98e9-b61a626a396b";
            MapsSettings.ApplicationContext.AuthenticationToken = "l0nSBWpKA8FMTtTV90lsWw";

            this.Dispatcher.BeginInvoke(new Action(this.MapFlightToCurentLocation));
            this.StoresMapItemsControl.ItemsSource = this.mainViewModel.StoreListGnbatu;
            
        }


        private async void OnMapHold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ReverseGeocodeQuery query;
            List<MapLocation> mapLocations;
            string pushpinContent;
            MapLocation mapLocation;

            query = new ReverseGeocodeQuery();
            query.GeoCoordinate = this.sampleMap1.ConvertViewportPointToGeoCoordinate(e.GetPosition(this.sampleMap1));

            mapLocations = (List<MapLocation>)await query.GetMapLocationsAsync();
            mapLocation = mapLocations.FirstOrDefault();

            if (mapLocation != null)
            {
                this.RouteDirectionsPushPin.GeoCoordinate = mapLocation.GeoCoordinate;

                pushpinContent = mapLocation.Information.Name;
                pushpinContent = string.IsNullOrEmpty(pushpinContent) ? mapLocation.Information.Description : null;
                pushpinContent = string.IsNullOrEmpty(pushpinContent) ? string.Format("{0} {1}", mapLocation.Information.Address.Street, mapLocation.Information.Address.City) : null;

                this.RouteDirectionsPushPin.Content = pushpinContent.Trim();
                this.RouteDirectionsPushPin.Visibility = Visibility.Visible;
            }
        }


        private void OnHideStores(object sender, EventArgs e)
        {
            this.ShowStores(false);
        }
        private void OnShowStores(object sender, EventArgs e)
        {
            this.ShowStores(true);
        }

        public void ShowStores(bool show)
        {
            ShowStoresIconMenuItem.IsEnabled = show;
            HideStoresIconMenuItem.IsEnabled = !show;

            foreach (Store store in this.mainViewModel.StoreListGnbatu)
            {
                store.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
            }

            if (show)
            {
                this.ChangeMode(MapMode.Stores);

                this.MapFlightToCurentLocation();
            }
        }

        private void MapFlightToCurentLocation()
        {
            LocationRectangle locationRectangle;
            
            locationRectangle = LocationRectangle.CreateBoundingRectangle(from store in this.mainViewModel.StoreListGnbatu select store.GeoCoordinate);

            this.sampleMap1.SetView(locationRectangle, new Thickness(20, 20, 20, 20));
        }

        private void MapExtensionsSetup(Map map)
        {
            ObservableCollection<DependencyObject> children = MapExtensions.GetChildren(map);
            var runtimeFields = this.GetType().GetRuntimeFields();

            foreach (DependencyObject i in children)
            {
                var info = i.GetType().GetProperty("Name");

                if (info != null)
                {
                    string name = (string)info.GetValue(i);

                    if (name != null)
                    {
                        foreach (FieldInfo j in runtimeFields)
                        {
                            if (j.Name == name)
                            {
                                j.SetValue(this, i);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private IAsyncOperation<Geoposition> GetUserLocation()
        {
            Geolocator geolocator;

            geolocator = new Geolocator();

            return geolocator.GetGeopositionAsync();
        }

        private void ChangeMode(MapMode mode)
        {
            if (this.Mode != mode)
            {
                this.Mode = mode;

                switch (this.Mode)
                {
                    case MapMode.Stores:
                        this.ShowStores(true);
                        this.RouteDirectionsPushPin.Visibility = Visibility.Collapsed;
                        if (this.MapRoute != null)
                        {
                            this.sampleMap1.RemoveRoute(this.MapRoute);
                        }

                        break;

                    case MapMode.Route:
                        this.ShowStores(false);
                        break;

                    case MapMode.Directions:
                        this.ShowStores(false);
                        if (this.MapRoute != null)
                        {
                            this.sampleMap1.RemoveRoute(this.MapRoute);
                        }

                        break;
                }
            }
        }


        #region Event handlers for App Bar buttons and menu items

        void ToggleLocation(object sender, EventArgs e)
        {
            switch (locationToggleStatus)
            {
                case ToggleStatus.ToggledOff:
                    ShowLocation();
                    CenterMapOnLocation();
                    locationToggleStatus = ToggleStatus.ToggledOn;
                    break;
                case ToggleStatus.ToggledOn:
                    sampleMap1.Layers.Remove(locationLayer);
                    locationLayer = null;
                    locationToggleStatus = ToggleStatus.ToggledOff;
                    break;
            }
        }

        //void ToggleLandmarks(object sender, EventArgs e)
        //{
        //    switch (landmarksToggleStatus)
        //    {
        //        case ToggleStatus.ToggledOff:
        //            sampleMap.LandmarksEnabled = true;
        //            if (sampleMap.ZoomLevel < MIN_ZOOMLEVEL_FOR_LANDMARKS)
        //            {
        //                sampleMap.ZoomLevel = MIN_ZOOMLEVEL_FOR_LANDMARKS;
        //            }
        //            landmarksToggleStatus = ToggleStatus.ToggledOn;
        //            break;
        //        case ToggleStatus.ToggledOn:
        //            sampleMap.LandmarksEnabled = false;
        //            landmarksToggleStatus = ToggleStatus.ToggledOff;
        //            break;
        //    }
        //
        //}

        void ZoomIn(object sender, EventArgs e)
        {
            if (sampleMap1.ZoomLevel < MAX_ZOOM_LEVEL)
            {
                sampleMap1.ZoomLevel++;
            }
        }

        void ZoomOut(object sender, EventArgs e)
        {
            if (sampleMap1.ZoomLevel > MIN_ZOOM_LEVEL)
            {
                sampleMap1.ZoomLevel--;
            }
        }

        #endregion

        #region Helper functions for App Bar button and menu item event handlers

        private void ShowLocation()
        {
            // Create a small circle to mark the current location.
            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(Colors.Green);
            myCircle.Height = 20;
            myCircle.Width = 20;
            myCircle.Opacity = 20;

            // Create a MapOverlay to contain the circle.
            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new System.Windows.Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = currentLocation;

            // Create a MapLayer to contain the MapOverlay.
            locationLayer = new MapLayer();
            locationLayer.Add(myLocationOverlay);

            // Add the MapLayer to the Map.
            sampleMap1.Layers.Add(locationLayer);

        }

        private async void GetLocation()
        {
            // Get current location.
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            currentLocation = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
        }

        private void CenterMapOnLocation()
        {
            sampleMap1.Center = currentLocation;
        }

        #endregion

        // Create the localized ApplicationBar.
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Opacity = 0.5;

            // Create buttons with localized strings from AppResources.
            // Toggle Location button.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/location.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarToggleLocationButtonText;
            appBarButton.Click += ToggleLocation;
            ApplicationBar.Buttons.Add(appBarButton);
            // Toggle Landmarks button.
            //appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/landmarks.png", UriKind.Relative));
            //appBarButton.Text = AppResources.AppBarToggleLandmarksButtonText;
            //appBarButton.Click += ToggleLandmarks;
            //ApplicationBar.Buttons.Add(appBarButton);
            // Zoom In button.
            appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/zoomin.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarZoomInButtonText;
            appBarButton.Click += ZoomIn;
            ApplicationBar.Buttons.Add(appBarButton);
            // Zoom Out button.
            appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/zoomout.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarZoomOutButtonText;
            appBarButton.Click += ZoomOut;
            ApplicationBar.Buttons.Add(appBarButton);

            // Create menu items with localized strings from AppResources.
            // Toggle Location menu item.

            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.ShowStoresIconMenuItem);
            appBarMenuItem.Click += OnShowStores;
            ApplicationBar.MenuItems.Add(appBarMenuItem);

            appBarMenuItem = new ApplicationBarMenuItem(AppResources.HideStoresIconMenuItem);
            appBarMenuItem.Click += OnHideStores;
            ApplicationBar.MenuItems.Add(appBarMenuItem);

        }


        private enum ToggleStatus
        {
            ToggledOff,
            ToggledOn
        }




    }
}
