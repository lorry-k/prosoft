﻿#pragma checksum "..\..\..\..\Views\Settings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4A672235A178F8A6685E7BB552B284822D7AD3D8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using EasySave_V3._0.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace EasySave_V3._0.Views {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Views\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox extension;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox software;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Extensions_OK;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Views\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Softwares_OK;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Views\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EnglishButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FrancaisButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EasySave V3;component/views/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Settings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 13 "..\..\..\..\Views\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back_Button);
            
            #line default
            #line hidden
            return;
            case 2:
            this.extension = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.software = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Extensions_OK = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Views\Settings.xaml"
            this.Extensions_OK.Click += new System.Windows.RoutedEventHandler(this.extensions_Valid);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Softwares_OK = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Views\Settings.xaml"
            this.Softwares_OK.Click += new System.Windows.RoutedEventHandler(this.softwares_Valid);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EnglishButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Views\Settings.xaml"
            this.EnglishButton.Click += new System.Windows.RoutedEventHandler(this.English);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FrancaisButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Views\Settings.xaml"
            this.FrancaisButton.Click += new System.Windows.RoutedEventHandler(this.Francais);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

