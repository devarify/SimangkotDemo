﻿#pragma checksum "C:\Users\Arif Yulianto\Documents\Visual Studio 2013\Projects\Simangkot\Simangkot\Angkot1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A2D1C7E351E63A12C9D6BA32338B002B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Toolkit;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Simangkot {
    
    
    public partial class Angkot1 : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Maps.Controls.Map sampleMap1;
        
        internal Microsoft.Phone.Maps.Toolkit.Pushpin RouteDirectionsPushPin;
        
        internal Microsoft.Phone.Maps.Toolkit.MapItemsControl StoresMapItemsControl;
        
        internal Microsoft.Phone.Maps.Toolkit.UserLocationMarker UserLocationMarker;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Simangkot;component/Angkot1.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.sampleMap1 = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("sampleMap1")));
            this.RouteDirectionsPushPin = ((Microsoft.Phone.Maps.Toolkit.Pushpin)(this.FindName("RouteDirectionsPushPin")));
            this.StoresMapItemsControl = ((Microsoft.Phone.Maps.Toolkit.MapItemsControl)(this.FindName("StoresMapItemsControl")));
            this.UserLocationMarker = ((Microsoft.Phone.Maps.Toolkit.UserLocationMarker)(this.FindName("UserLocationMarker")));
        }
    }
}

