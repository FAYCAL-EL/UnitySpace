﻿#pragma checksum "..\..\Chef_Index.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A0005CBA30E3C3C1BD0A2A909D2C1A17B2F6D7A2CC9D993682BF163AE81F6304"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using UnitySpace;


namespace UnitySpace {
    
    
    /// <summary>
    /// Chef_Index
    /// </summary>
    public partial class Chef_Index : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Chef_Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Rbtn1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Chef_Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Rbtn2;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Chef_Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Rbtn3;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\Chef_Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button notif;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\Chef_Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock notifBullet;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\Chef_Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup NotificationPopup;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\Chef_Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock notifBarCounter;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\Chef_Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel notifactionContent;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\Chef_Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image profil;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\Chef_Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl CC;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UnitySpace;component/chef_index.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Chef_Index.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\Chef_Index.xaml"
            ((UnitySpace.Chef_Index)(target)).LocationChanged += new System.EventHandler(this.MainWindow_LocationChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Rbtn1 = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Chef_Index.xaml"
            this.Rbtn1.Click += new System.Windows.RoutedEventHandler(this.create_meeting);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Rbtn2 = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Chef_Index.xaml"
            this.Rbtn2.Click += new System.Windows.RoutedEventHandler(this.upcoming_meeting);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Rbtn3 = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\Chef_Index.xaml"
            this.Rbtn3.Click += new System.Windows.RoutedEventHandler(this.meeting);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 59 "..\..\Chef_Index.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.logout);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 88 "..\..\Chef_Index.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.create_meeting);
            
            #line default
            #line hidden
            return;
            case 7:
            this.notif = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\Chef_Index.xaml"
            this.notif.Click += new System.Windows.RoutedEventHandler(this.ButtonNotif_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.notifBullet = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.NotificationPopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 10:
            this.notifBarCounter = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.notifactionContent = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 12:
            this.profil = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.CC = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

