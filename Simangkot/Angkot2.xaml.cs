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

    

    public partial class Angkot2 : PhoneApplicationPage
    {
        readonly MapsViewModel mainViewModel1 = new MapsViewModel();

        const int MIN_ZOOM_LEVEL = 1;
        const int MAX_ZOOM_LEVEL = 20;
        const int MIN_ZOOMLEVEL_FOR_LANDMARKS = 16;

        ToggleStatus locationToggleStatus = ToggleStatus.ToggledOff;

        GeoCoordinate currentLocation = new GeoCoordinate();
        MapLayer locationLayer = null;
        MapPolyline polyline = null;

        // Constructor.
        public Angkot2()
        {

            InitializeComponent();

            // Create the localized ApplicationBar.
            BuildLocalizedApplicationBar();

            // Get current location.
            GetLocation();

            this.MapExtensionsSetup(this.sampleMap2);

            this.DataContext = this.mainViewModel1;

            HideStoresIconMenuItem = (ApplicationBarMenuItem)ApplicationBar.MenuItems[0];
            ShowStoresIconMenuItem = (ApplicationBarMenuItem)ApplicationBar.MenuItems[1];

            
            this.Loaded += this.sampleMap_Loaded;
            this.ShowStores(true);

            polyline = null;
            polyline = new MapPolyline();
            polyline.StrokeColor = Color.FromArgb(0xff, 0x00, 0x00, 0xff);
            polyline.StrokeThickness = 10;

            polyline.Path = new GeoCoordinateCollection() { 
                            new GeoCoordinate(-6.86668 , 107.620938),
new GeoCoordinate(-6.86807 , 107.620611),
new GeoCoordinate(-6.869132 , 107.620622),
new GeoCoordinate(-6.870987 , 107.620046),
new GeoCoordinate(-6.872566 , 107.619891),
new GeoCoordinate(-6.875961 , 107.61839),
new GeoCoordinate(-6.878233 , 107.616781),
new GeoCoordinate(-6.881703 , 107.615848),
new GeoCoordinate(-6.88382 , 107.614158),
new GeoCoordinate(-6.88522 , 107.613739),
new GeoCoordinate(-6.899813 , 107.612692),
new GeoCoordinate(-6.903172 , 107.611278),
new GeoCoordinate(-6.904840 , 107.610680),
new GeoCoordinate(-6.906978 , 107.61058),
new GeoCoordinate(-6.913549 , 107.610333),
new GeoCoordinate(-6.913941 , 107.609898),
new GeoCoordinate(-6.913882 , 107.609003),
new GeoCoordinate(-6.916242 , 107.608981),
new GeoCoordinate(-6.916258 , 107.608316),
new GeoCoordinate(-6.916081 , 107.607951),
new GeoCoordinate(-6.915612 , 107.607543),
new GeoCoordinate(-6.915502 , 107.607146),
new GeoCoordinate(-6.915491 , 107.60617),
new GeoCoordinate(-6.91584 , 107.604491),
new GeoCoordinate(-6.914821 , 107.60455),
new GeoCoordinate(-6.914762 , 107.602961),
new GeoCoordinate(-6.914841 , 107.60258),
new GeoCoordinate(-6.914708 , 107.60043),
new GeoCoordinate(-6.915389 , 107.600629),
new GeoCoordinate(-6.9158 , 107.600741),
new GeoCoordinate(-6.915928 , 107.600215),
new GeoCoordinate(-6.915059 , 107.599998),
new GeoCoordinate(-6.914928 , 107.60043),
new GeoCoordinate(-6.914708 , 107.60043),
new GeoCoordinate(-6.914837 , 107.602628),
new GeoCoordinate(-6.914778 , 107.602919),
new GeoCoordinate(-6.914799 , 107.604571),
new GeoCoordinate(-6.91474 , 107.604657),
new GeoCoordinate(-6.915016 , 107.606586),
new GeoCoordinate(-6.915298 , 107.606948),
new GeoCoordinate(-6.914402 , 107.607163),
new GeoCoordinate(-6.913968 , 107.608042),
new GeoCoordinate(-6.913882 , 107.609003),
new GeoCoordinate(-6.910586 , 107.60902),
new GeoCoordinate(-6.90907 , 107.608171),
new GeoCoordinate(-6.908819 , 107.607951),
new GeoCoordinate(-6.907724 , 107.607597),
new GeoCoordinate(-6.906544 , 107.60784),
new GeoCoordinate(-6.906538 , 107.607978),
new GeoCoordinate(-6.906917 , 107.610595)
                    
                        };
            sampleMap2.MapElements.Add(polyline);
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

            this.Dispatcher.BeginInvoke(new Action(this.MapFlightToCurentLocation2));
            this.StoresMapItemsControl2.ItemsSource = this.mainViewModel1.StoreListDago;
            
        }


        private async void OnMapHold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ReverseGeocodeQuery query;
            List<MapLocation> mapLocations;
            string pushpinContent2;
            MapLocation mapLocation;

            query = new ReverseGeocodeQuery();
            query.GeoCoordinate = this.sampleMap2.ConvertViewportPointToGeoCoordinate(e.GetPosition(this.sampleMap2));

            mapLocations = (List<MapLocation>)await query.GetMapLocationsAsync();
            mapLocation = mapLocations.FirstOrDefault();

            if (mapLocation != null)
            {
                this.RouteDirectionsPushPin2.GeoCoordinate = mapLocation.GeoCoordinate;

                pushpinContent2 = mapLocation.Information.Name;
                pushpinContent2 = string.IsNullOrEmpty(pushpinContent2) ? mapLocation.Information.Description : null;
                pushpinContent2 = string.IsNullOrEmpty(pushpinContent2) ? string.Format("{0} {1}", mapLocation.Information.Address.Street, mapLocation.Information.Address.City) : null;

                this.RouteDirectionsPushPin2.Content = pushpinContent2.Trim();
                this.RouteDirectionsPushPin2.Visibility = Visibility.Visible;
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

            foreach (Store store in this.mainViewModel1.StoreListDago)
            {
                store.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
            }

            if (show)
            {
                this.ChangeMode(MapMode.Stores);

                this.MapFlightToCurentLocation2();
            }
        }

        private void MapFlightToCurentLocation2()
        {
            LocationRectangle locationRectangle;
            
            locationRectangle = LocationRectangle.CreateBoundingRectangle(from store in this.mainViewModel1.StoreListDago select store.GeoCoordinate);

            this.sampleMap2.SetView(locationRectangle, new Thickness(20, 20, 20, 20));
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
                        this.RouteDirectionsPushPin2.Visibility = Visibility.Collapsed;
                        if (this.MapRoute != null)
                        {
                            this.sampleMap2.RemoveRoute(this.MapRoute);
                        }

                        break;

                    case MapMode.Route:
                        this.ShowStores(false);
                        break;

                    case MapMode.Directions:
                        this.ShowStores(false);
                        if (this.MapRoute != null)
                        {
                            this.sampleMap2.RemoveRoute(this.MapRoute);
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
                    sampleMap2.Layers.Remove(locationLayer);
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
            if (sampleMap2.ZoomLevel < MAX_ZOOM_LEVEL)
            {
                sampleMap2.ZoomLevel++;
            }
        }

        void ZoomOut(object sender, EventArgs e)
        {
            if (sampleMap2.ZoomLevel > MIN_ZOOM_LEVEL)
            {
                sampleMap2.ZoomLevel--;
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
            sampleMap2.Layers.Add(locationLayer);

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
            sampleMap2.Center = currentLocation;
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
