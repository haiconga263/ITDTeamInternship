﻿#pragma checksum "..\..\..\View\UpdatePrecheckStatusView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "95756134D4C769BB40A6794E7A18475F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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


namespace TollTicketManagement.View {
    
    
    /// <summary>
    /// UpdatePrecheckStatusView
    /// </summary>
    public partial class UpdatePrecheckStatusView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\View\UpdatePrecheckStatusView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\View\UpdatePrecheckStatusView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUpdateStatus;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\View\UpdatePrecheckStatusView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkAuto;
        
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
            System.Uri resourceLocater = new System.Uri("/TollTicketManagement;component/view/updateprecheckstatusview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\UpdatePrecheckStatusView.xaml"
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
            
            #line 5 "..\..\..\View\UpdatePrecheckStatusView.xaml"
            ((TollTicketManagement.View.UpdatePrecheckStatusView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UpdatePrecheckStatusView_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\..\View\UpdatePrecheckStatusView.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblUpdateStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.chkAuto = ((System.Windows.Controls.CheckBox)(target));
            
            #line 9 "..\..\..\View\UpdatePrecheckStatusView.xaml"
            this.chkAuto.Unchecked += new System.Windows.RoutedEventHandler(this.chkAuto_Unchecked);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\View\UpdatePrecheckStatusView.xaml"
            this.chkAuto.Checked += new System.Windows.RoutedEventHandler(this.chkAuto_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

