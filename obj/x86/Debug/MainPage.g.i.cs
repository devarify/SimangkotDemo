﻿

#pragma checksum "C:\Users\Arif Yulianto\Documents\Visual Studio 2013\Projects\C#\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E55A1190F66496D438A697E77972893C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Geofencing4SqSample
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid ContentRoot; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid Header; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid InnerContent; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid Footer; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock Status; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid ListViewColumn; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid RightColumn; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ScrollViewer LoggerScrollViewer; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox LoggerTextBox; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Maps.Map Map; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Maps.MapLayer CurrentPositionMapLayer; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Maps.MapLayer GeofencesMapLayer; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Maps.MapLayer VenuesMapLayer; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Bing.Maps.MapLayer SelectionsMapLayer; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ListView ItemsListView; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock Title; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.AppBar MyBottomAppBar; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button AddGeofencesButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button AddGeofenceHereButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button CheckinButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button DeleteGeofencesButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///MainPage.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            ContentRoot = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("ContentRoot");
            Header = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("Header");
            InnerContent = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("InnerContent");
            Footer = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("Footer");
            Status = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("Status");
            ListViewColumn = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("ListViewColumn");
            RightColumn = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("RightColumn");
            LoggerScrollViewer = (global::Windows.UI.Xaml.Controls.ScrollViewer)this.FindName("LoggerScrollViewer");
            LoggerTextBox = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("LoggerTextBox");
            Map = (global::Bing.Maps.Map)this.FindName("Map");
            CurrentPositionMapLayer = (global::Bing.Maps.MapLayer)this.FindName("CurrentPositionMapLayer");
            GeofencesMapLayer = (global::Bing.Maps.MapLayer)this.FindName("GeofencesMapLayer");
            VenuesMapLayer = (global::Bing.Maps.MapLayer)this.FindName("VenuesMapLayer");
            SelectionsMapLayer = (global::Bing.Maps.MapLayer)this.FindName("SelectionsMapLayer");
            ItemsListView = (global::Windows.UI.Xaml.Controls.ListView)this.FindName("ItemsListView");
            Title = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("Title");
            MyBottomAppBar = (global::Windows.UI.Xaml.Controls.AppBar)this.FindName("MyBottomAppBar");
            AddGeofencesButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("AddGeofencesButton");
            AddGeofenceHereButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("AddGeofenceHereButton");
            CheckinButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("CheckinButton");
            DeleteGeofencesButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("DeleteGeofencesButton");
        }
    }
}



