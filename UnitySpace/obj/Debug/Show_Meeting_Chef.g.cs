﻿#pragma checksum "..\..\Show_Meeting_Chef.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F13EB9A5C81874E18EEA6DF87FE3F060F98A3E942C4E26ECC9D132CAE2905C62"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// Show_Meeting_Chef
    /// </summary>
    public partial class Show_Meeting_Chef : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\Show_Meeting_Chef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock meetingTitle;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Show_Meeting_Chef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock meetingDescription;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Show_Meeting_Chef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock meetingDate;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Show_Meeting_Chef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock meetingPlace;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Show_Meeting_Chef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel participants;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Show_Meeting_Chef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AttachButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Show_Meeting_Chef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AttachmentMessage;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\Show_Meeting_Chef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DownloadButton;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\Show_Meeting_Chef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DownloadMessaage;
        
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
            System.Uri resourceLocater = new System.Uri("/UnitySpace;component/show_meeting_chef.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Show_Meeting_Chef.xaml"
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
            
            #line 19 "..\..\Show_Meeting_Chef.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.meetingTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.meetingDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.meetingDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.meetingPlace = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.participants = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.AttachButton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\Show_Meeting_Chef.xaml"
            this.AttachButton.Click += new System.Windows.RoutedEventHandler(this.AttachButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AttachmentMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.DownloadButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\Show_Meeting_Chef.xaml"
            this.DownloadButton.Click += new System.Windows.RoutedEventHandler(this.DownloadButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.DownloadMessaage = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

