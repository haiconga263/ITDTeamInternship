﻿#pragma checksum "..\..\..\View\ManagementView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "598F1035588FF1385D3807E9C3E81A9F"
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace TollTicketManagement {
    
    
    /// <summary>
    /// ManagementView
    /// </summary>
    public partial class ManagementView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel mainSpanel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTitle;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpFromDate;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbShift;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkRealTime;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtSumInStock;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvListSearchResult;
        
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
            System.Uri resourceLocater = new System.Uri("/TollTicketManagement;component/view/managementview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ManagementView.xaml"
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
            
            #line 6 "..\..\..\View\ManagementView.xaml"
            ((TollTicketManagement.ManagementView)(target)).Closed += new System.EventHandler(this.ManagementView_OnClosed);
            
            #line default
            #line hidden
            
            #line 6 "..\..\..\View\ManagementView.xaml"
            ((TollTicketManagement.ManagementView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainSpanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.txtTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.dtpFromDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.cbShift = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.chkRealTime = ((System.Windows.Controls.CheckBox)(target));
            
            #line 38 "..\..\..\View\ManagementView.xaml"
            this.chkRealTime.Checked += new System.Windows.RoutedEventHandler(this.chkRealTime_Checked);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\View\ManagementView.xaml"
            this.chkRealTime.Unchecked += new System.Windows.RoutedEventHandler(this.chkRealTime_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\View\ManagementView.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtSumInStock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.dgvListSearchResult = ((System.Windows.Controls.DataGrid)(target));
            
            #line 44 "..\..\..\View\ManagementView.xaml"
            this.dgvListSearchResult.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dgvListSearchResult_LoadingRow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

