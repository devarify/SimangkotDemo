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

    

    public partial class Angkot3 : PhoneApplicationPage
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
        public Angkot3()
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
new GeoCoordinate(-6.885091 , 107.596563),
new GeoCoordinate(-6.885786 , 107.59685),
new GeoCoordinate(-6.886679 , 107.596659),
new GeoCoordinate(-6.887709 , 107.596761),
new GeoCoordinate(-6.888807 , 107.597709),
new GeoCoordinate(-6.889441 , 107.598515),
new GeoCoordinate(-6.890047 , 107.599856),
new GeoCoordinate(-6.894082 , 107.598703),
new GeoCoordinate(-6.894811 , 107.600382),
new GeoCoordinate(-6.895309 , 107.600944),
new GeoCoordinate(-6.895673 , 107.600929),
new GeoCoordinate(-6.896077 , 107.600752),
new GeoCoordinate(-6.896267 , 107.600296),
new GeoCoordinate(-6.895938 , 107.598231),
new GeoCoordinate(-6.89685 , 107.597303),
new GeoCoordinate(-6.906452 , 107.597609),
new GeoCoordinate(-6.90715 , 107.592019),
new GeoCoordinate(-6.90679 , 107.587792),
new GeoCoordinate(-6.907651 , 107.582789),
new GeoCoordinate(-6.907471 , 107.579742),
new GeoCoordinate(-6.907701 , 107.579258),
new GeoCoordinate(-6.908131 , 107.578989),
new GeoCoordinate(-6.913517 , 107.587239),
new GeoCoordinate(-6.913748 , 107.587169),
new GeoCoordinate(-6.915357 , 107.586622),
new GeoCoordinate(-6.915443 , 107.586914),
new GeoCoordinate(-6.914153 , 107.588525),
new GeoCoordinate(-6.91452 , 107.588972),
new GeoCoordinate(-6.911269 , 107.58946),
new GeoCoordinate(-6.906995 , 107.592929),
new GeoCoordinate(-6.90641 , 107.596245),
new GeoCoordinate(-6.903888 , 107.596369),
new GeoCoordinate(-6.904022 , 107.59755),
new GeoCoordinate(-6.886988 , 107.596686),
new GeoCoordinate(-6.885699 , 107.596412),
new GeoCoordinate(-6.885091 , 107.596563),
new GeoCoordinate(-6.878321 , 107.596219),
new GeoCoordinate(-6.877237 , 107.594767),
new GeoCoordinate(-6.877914 , 107.593668),
new GeoCoordinate(-6.87771 , 107.590549),
new GeoCoordinate(-6.875632 , 107.590595),
new GeoCoordinate(-6.874147 , 107.590937),
new GeoCoordinate(-6.874023 , 107.590574),
new GeoCoordinate(-6.873190 , 107.590617),
new GeoCoordinate(-6.872909 , 107.5903),
new GeoCoordinate(-6.871954 , 107.590197),
new GeoCoordinate(-6.87119 , 107.590505),
new GeoCoordinate(-6.86992 , 107.590629),
new GeoCoordinate(-6.868393 , 107.585758),
new GeoCoordinate(-6.868056 , 107.583075),
new GeoCoordinate(-6.870151 , 107.58239),
new GeoCoordinate(-6.869829 , 107.581359),
new GeoCoordinate(-6.870374 , 107.580943),
new GeoCoordinate(-6.874281 , 107.580186),
new GeoCoordinate(-6.876438 , 107.579252),
new GeoCoordinate(-6.876068 , 107.57834),
new GeoCoordinate(-6.881019 , 107.576162),
new GeoCoordinate(-6.882221 , 107.576473),
new GeoCoordinate(-6.882709 , 107.57496),
new GeoCoordinate(-6.880521 , 107.574279),
new GeoCoordinate(-6.878852 , 107.57503),
new GeoCoordinate(-6.879662 , 107.576779),
new GeoCoordinate(-6.876068 , 107.57834),
new GeoCoordinate(-6.876438 , 107.579252),
new GeoCoordinate(-6.874137 , 107.580207),
new GeoCoordinate(-6.870446 , 107.580915),
new GeoCoordinate(-6.869829 , 107.581353),
new GeoCoordinate(-6.869851 , 107.581478),
new GeoCoordinate(-6.867877 , 107.582197),
new GeoCoordinate(-6.868129 , 107.582969),
new GeoCoordinate(-6.868023 , 107.583206)
                    
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
            this.StoresMapItemsControl.ItemsSource = this.mainViewModel.StoreListSarijadi;
            
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

            foreach (Store store in this.mainViewModel.StoreListSarijadi)
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
            
            locationRectangle = LocationRectangle.CreateBoundingRectangle(from store in this.mainViewModel.StoreListSarijadi select store.GeoCoordinate);

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
