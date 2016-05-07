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

    #region Enums

    /// <summary>
    /// Map Mode
    /// </summary>
    public enum MapMode
    {
        /// <summary>
        /// Stores are displayed in the map
        /// </summary>
        Stores,

        /// <summary>
        /// Map is showing directions using a Windows Phone Task
        /// </summary>
        Directions,

        /// <summary>
        /// Map is showing a route in the map
        /// </summary>
        Route
    }

    #endregion

    public partial class Angkot1 : PhoneApplicationPage
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
        public Angkot1()
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
                            new GeoCoordinate(-6.876051 , 107.546066),
                            new GeoCoordinate(-6.880003 , 107.543307),
                            new GeoCoordinate(-6.880535 , 107.543320),
                            new GeoCoordinate(-6.880531 , 107.54301),
                            new GeoCoordinate(-6.878980 , 107.539140),
                            new GeoCoordinate(-6.877783 , 107.539258),
                            new GeoCoordinate(-6.877592 , 107.53911),
                            new GeoCoordinate(-6.876061 , 107.536190),
                            new GeoCoordinate(-6.87567 , 107.536405),
                            new GeoCoordinate(-6.875347 , 107.536774),
                            new GeoCoordinate(-6.871742 , 107.539065),
                            new GeoCoordinate(-6.870791 , 107.537369),
                            new GeoCoordinate(-6.86984782022658 , 107.534694671631),
                            new GeoCoordinate(-6.868924 , 107.535133),
                            new GeoCoordinate(-6.86132 , 107.543906),
                            new GeoCoordinate(-6.8612517338385 , 107.544575929),
                            new GeoCoordinate(-6.860538 , 107.546749),
                            new GeoCoordinate(-6.863024 , 107.55227),
                            new GeoCoordinate(-6.865154 , 107.550999),
                            new GeoCoordinate(-6.865746 , 107.550338),
                            new GeoCoordinate(-6.865315 , 107.548807),
                            new GeoCoordinate(-6.865375 , 107.548390),
                            new GeoCoordinate(-6.868070 , 107.545654),
                            new GeoCoordinate(-6.868624 , 107.544796),
                            new GeoCoordinate(-6.869849 , 107.543916),
                            new GeoCoordinate(-6.870058 , 107.544149),
                            new GeoCoordinate(-6.871471 , 107.544678),
                            new GeoCoordinate(-6.872662 , 107.544479),
                            new GeoCoordinate(-6.8744 , 107.543519),
                            new GeoCoordinate(-6.87816 , 107.549441),
                            new GeoCoordinate(-6.910481 , 107.569038),
                            new GeoCoordinate(-6.913651 , 107.577572),
                            new GeoCoordinate(-6.916532 , 107.591032),
                            new GeoCoordinate(-6.916189 , 107.602201),
                            new GeoCoordinate(-6.91584 , 107.604491),
                            new GeoCoordinate(-6.914778 , 107.604572),
                            new GeoCoordinate(-6.914949 , 107.606412),
                            new GeoCoordinate(-6.915268 , 107.606969),
                            new GeoCoordinate(-6.914402 , 107.607163),
                            new GeoCoordinate(-6.914758 , 107.606784),
                            new GeoCoordinate(-6.914472 , 107.604598),
                            new GeoCoordinate(-6.912788 , 107.604679),
                            new GeoCoordinate(-6.912338 , 107.598223),
                            new GeoCoordinate(-6.912171 , 107.597979),
                            new GeoCoordinate(-6.906452 , 107.597609),
                            new GeoCoordinate(-6.90715 , 107.592019),
                            new GeoCoordinate(-6.90679 , 107.587792),
                            new GeoCoordinate(-6.907661 , 107.58265),
                            new GeoCoordinate(-6.907471 , 107.579752),
                            new GeoCoordinate(-6.907681 , 107.579278),
                            new GeoCoordinate(-6.909124 , 107.578618),
                            new GeoCoordinate(-6.917498 , 107.57672),
                            new GeoCoordinate(-6.917261 , 107.574552),
                            new GeoCoordinate(-6.910374 , 107.568965)
                    
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
            this.StoresMapItemsControl.ItemsSource = this.mainViewModel.StoreList;
            
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

            foreach (Store store in this.mainViewModel.StoreList)
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
            
            locationRectangle = LocationRectangle.CreateBoundingRectangle(from store in this.mainViewModel.StoreList select store.GeoCoordinate);

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
