﻿#pragma checksum "C:\dong_tfs\Projects\DONGEnergy.SD.Portal.SLWebPartWrapper\DONGEnergy.SD.Portal.SLWebpartWrapper\Kabellaegning\Kabellaegning\InfoControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1AAD2F4D40CFA0C965EE54984DF0BCAB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Kabellaegning {
    
    
    public partial class InfoControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Header;
        
        internal System.Windows.Controls.Border InfoMessageStatusBorder;
        
        internal System.Windows.Controls.TextBlock InfoMessageStatus;
        
        internal System.Windows.Controls.ItemsControl SearchResultItems;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Kabellaegning;component/InfoControl.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Header = ((System.Windows.Controls.TextBlock)(this.FindName("Header")));
            this.InfoMessageStatusBorder = ((System.Windows.Controls.Border)(this.FindName("InfoMessageStatusBorder")));
            this.InfoMessageStatus = ((System.Windows.Controls.TextBlock)(this.FindName("InfoMessageStatus")));
            this.SearchResultItems = ((System.Windows.Controls.ItemsControl)(this.FindName("SearchResultItems")));
        }
    }
}
