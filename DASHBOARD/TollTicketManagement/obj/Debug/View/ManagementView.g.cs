﻿#pragma checksum "..\..\..\View\ManagementView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A67CE5CCE4FC4E74C976D62E6858EB77"
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


namespace TollTicketManagement {
    
    
    /// <summary>
    /// ManagementView
    /// </summary>
    public partial class ManagementView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel mainSpanel;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvListSearchResult;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid footerGrid;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbOnWayTicket;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\View\ManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtCMOTicket;
        
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
            
            #line 4 "..\..\..\View\ManagementView.xaml"
            ((TollTicketManagement.ManagementView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainSpanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.dgvListSearchResult = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.footerGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.tbOnWayTicket = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.txtCMOTicket = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

