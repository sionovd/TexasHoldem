﻿#pragma checksum "..\..\UserControlMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0402F43F875E1EBD1A0E64D5E281C013"
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
    /// Menu
    /// </summary>
    public partial class Menu : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\UserControlMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnProfile;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\UserControlMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\UserControlMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateGame;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\UserControlMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnJoinGame;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\UserControlMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSpectateGame;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\UserControlMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWatchReplayes;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/usercontrolmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControlMenu.xaml"
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
            this.btnProfile = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\UserControlMenu.xaml"
            this.btnProfile.Click += new System.Windows.RoutedEventHandler(this.Button_Click_Profile);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnLogout = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\UserControlMenu.xaml"
            this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.Button_Click_Logout);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnCreateGame = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\UserControlMenu.xaml"
            this.btnCreateGame.Click += new System.Windows.RoutedEventHandler(this.Button_Click_CreateGame);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnJoinGame = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\UserControlMenu.xaml"
            this.btnJoinGame.Click += new System.Windows.RoutedEventHandler(this.btnJoinActiveGame_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSpectateGame = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\UserControlMenu.xaml"
            this.btnSpectateGame.Click += new System.Windows.RoutedEventHandler(this.btnSpectateGame_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnWatchReplayes = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\UserControlMenu.xaml"
            this.btnWatchReplayes.Click += new System.Windows.RoutedEventHandler(this.btnWatchReplayes_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
