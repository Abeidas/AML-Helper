﻿#pragma checksum "..\..\..\Controller\CaexTreeView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1886BEA7F8B3215C296166738B793743"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AMLHelper.ElementExtraction;
using AMLHelper.Model;
using AMLHelper.View;
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


namespace AMLHelper.Controller {
    
    
    /// <summary>
    /// CaexTreeView
    /// </summary>
    public partial class CaexTreeView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 37 "..\..\..\Controller\CaexTreeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem NewInstanceHierachy;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Controller\CaexTreeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem RestoreTab;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Controller\CaexTreeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem DeleteAllTabs;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Controller\CaexTreeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Controller\CaexTreeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CleanSearchboxButton;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Controller\CaexTreeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AMLHelper.View.Resultview Resultview;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\Controller\CaexTreeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView Tree;
        
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
            System.Uri resourceLocater = new System.Uri("/AMLHelper;component/controller/caextreeview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controller\CaexTreeView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 18 "..\..\..\Controller\CaexTreeView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenInNewTabClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 23 "..\..\..\Controller\CaexTreeView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenInCurrentTabClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 28 "..\..\..\Controller\CaexTreeView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveElementClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NewInstanceHierachy = ((System.Windows.Controls.MenuItem)(target));
            
            #line 37 "..\..\..\Controller\CaexTreeView.xaml"
            this.NewInstanceHierachy.Click += new System.Windows.RoutedEventHandler(this.AddEmptyHierarchy);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RestoreTab = ((System.Windows.Controls.MenuItem)(target));
            
            #line 42 "..\..\..\Controller\CaexTreeView.xaml"
            this.RestoreTab.Click += new System.Windows.RoutedEventHandler(this.RestoreLastTab);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteAllTabs = ((System.Windows.Controls.MenuItem)(target));
            
            #line 47 "..\..\..\Controller\CaexTreeView.xaml"
            this.DeleteAllTabs.Click += new System.Windows.RoutedEventHandler(this.RemoveAllElementsClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 87 "..\..\..\Controller\CaexTreeView.xaml"
            this.TextBox.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBox_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 88 "..\..\..\Controller\CaexTreeView.xaml"
            this.TextBox.LostFocus += new System.Windows.RoutedEventHandler(this.textBox_LostFocus);
            
            #line default
            #line hidden
            
            #line 90 "..\..\..\Controller\CaexTreeView.xaml"
            this.TextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CleanSearchboxButton = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\Controller\CaexTreeView.xaml"
            this.CleanSearchboxButton.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CleanSearchTextBox);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Resultview = ((AMLHelper.View.Resultview)(target));
            return;
            case 10:
            this.Tree = ((System.Windows.Controls.TreeView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 11:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 119 "..\..\..\Controller\CaexTreeView.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.DoubleClickOnElement);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.MouseDownEvent;
            
            #line 120 "..\..\..\Controller\CaexTreeView.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.WheelOnElement);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

