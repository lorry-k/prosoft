﻿#pragma checksum "..\..\..\..\Views\CreateFR.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5C629F1806295D8DEE8B1424F84BC363579A86BC"
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
    /// CreateFR
    /// </summary>
    public partial class CreateFR : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Views\CreateFR.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid source;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Views\CreateFR.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\CreateFR.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Full;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\CreateFR.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Diff;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Views\CreateFR.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox source1;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\CreateFR.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox destination;
        
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
            System.Uri resourceLocater = new System.Uri("/EasySave V3;V1.0.0.0;component/views/createfr.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\CreateFR.xaml"
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
            this.source = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Full = ((System.Windows.Controls.RadioButton)(target));
            
            #line 19 "..\..\..\..\Views\CreateFR.xaml"
            this.Full.Checked += new System.Windows.RoutedEventHandler(this.Full_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Diff = ((System.Windows.Controls.RadioButton)(target));
            
            #line 20 "..\..\..\..\Views\CreateFR.xaml"
            this.Diff.Checked += new System.Windows.RoutedEventHandler(this.Diff_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 21 "..\..\..\..\Views\CreateFR.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back_Button);
            
            #line default
            #line hidden
            return;
            case 6:
            this.source1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.destination = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 24 "..\..\..\..\Views\CreateFR.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Create_Valid);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 25 "..\..\..\..\Views\CreateFR.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Source_Button);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 26 "..\..\..\..\Views\CreateFR.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Destination_Button);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
