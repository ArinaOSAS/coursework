﻿#pragma checksum "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16BEA1534F75247588A373A9B1F8A6DBB4402512"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ArgocomTRPO.WindowsAdmin;
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


namespace ArgocomTRPO.WindowsAdmin {
    
    
    /// <summary>
    /// TechnologyWindowAdmin
    /// </summary>
    public partial class TechnologyWindowAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 62 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxSelection;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Search;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Grid_Technology;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ArgocomTRPO;component/windowsadmin/technologywindowadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 41 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.WrapPanel_mouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 42 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_close);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 55 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_minimized);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ComboBoxSelection = ((System.Windows.Controls.ComboBox)(target));
            
            #line 64 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            this.ComboBoxSelection.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxSelection_OnSelected);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 81 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonBase_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TextBox_Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 91 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            this.TextBox_Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_Search_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Grid_Technology = ((System.Windows.Controls.DataGrid)(target));
            
            #line 110 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            this.Grid_Technology.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Grid_Technology_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 132 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_AddTechnology);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 141 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_Delete);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 150 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_Breaking);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 154 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_Report);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 163 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_Account);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 166 "..\..\..\..\WindowsAdmin\TechnologyWindowAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_Broken);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

