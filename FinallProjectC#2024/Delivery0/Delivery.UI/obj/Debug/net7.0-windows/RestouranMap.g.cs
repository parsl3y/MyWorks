﻿#pragma checksum "..\..\..\RestouranMap.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5A9B7AD35A85DD78B8510D9A2253426C561E7145"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Delivery.UI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Delivery.UI {
    
    
    /// <summary>
    /// RestouranMap
    /// </summary>
    public partial class RestouranMap : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\RestouranMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FirstBtn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\RestouranMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Rest2;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\RestouranMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button adminBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\RestouranMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitBtn;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\RestouranMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RelogBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Delivery.UI;component/restouranmap.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RestouranMap.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.FirstBtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\RestouranMap.xaml"
            this.FirstBtn.Click += new System.Windows.RoutedEventHandler(this.Rest1Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 24 "..\..\..\RestouranMap.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Rest3Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Rest2 = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\RestouranMap.xaml"
            this.Rest2.Click += new System.Windows.RoutedEventHandler(this.Rest2Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.adminBtn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\RestouranMap.xaml"
            this.adminBtn.Click += new System.Windows.RoutedEventHandler(this.adminBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ExitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\RestouranMap.xaml"
            this.ExitBtn.Click += new System.Windows.RoutedEventHandler(this.ExitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RelogBtn = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\RestouranMap.xaml"
            this.RelogBtn.Click += new System.Windows.RoutedEventHandler(this.RelogBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

