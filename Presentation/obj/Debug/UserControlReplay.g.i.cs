﻿#pragma checksum "..\..\UserControlReplay.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2973CBA8F5CDB00082A5B48CC6710DED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Presentation;
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


namespace Presentation {
    
    
    /// <summary>
    /// UserControlReplay
    /// </summary>
    public partial class UserControlReplay : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 90 "..\..\UserControlReplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image com3;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\UserControlReplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image com4;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\UserControlReplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image com2;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\UserControlReplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image com5;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\UserControlReplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image com1;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\UserControlReplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLeaveTable;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\UserControlReplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid stateGameBoard;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\UserControlReplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtPotSize;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\UserControlReplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPotSize;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/usercontrolreplay.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControlReplay.xaml"
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
            this.com3 = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.com4 = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.com2 = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.com5 = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.com1 = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.btnLeaveTable = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\UserControlReplay.xaml"
            this.btnLeaveTable.Click += new System.Windows.RoutedEventHandler(this.BtnLeaveTable_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.stateGameBoard = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.txtPotSize = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.lblPotSize = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

