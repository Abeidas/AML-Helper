﻿#pragma checksum "..\..\..\View\IEPanel.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1BF92F111A37056804BDEB723292CD41"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
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


namespace AMLHelper.View {
    
    
    /// <summary>
    /// IEPanel
    /// </summary>
    public partial class IEPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\View\IEPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ExistingsInternalElements;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\View\IEPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox useInternalLinks;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\IEPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button upButton;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\View\IEPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button downButton;
        
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
            System.Uri resourceLocater = new System.Uri("/AMLHelper;component/view/iepanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\IEPanel.xaml"
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
            this.ExistingsInternalElements = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            
            #line 21 "..\..\..\View\IEPanel.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenInNewTabClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 26 "..\..\..\View\IEPanel.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenInCurrentTabClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.useInternalLinks = ((System.Windows.Controls.CheckBox)(target));
            
            #line 53 "..\..\..\View\IEPanel.xaml"
            this.useInternalLinks.Checked += new System.Windows.RoutedEventHandler(this.useInternalLinks_Checked);
            
            #line default
            #line hidden
            
            #line 54 "..\..\..\View\IEPanel.xaml"
            this.useInternalLinks.Unchecked += new System.Windows.RoutedEventHandler(this.useInternalLinks_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.upButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\View\IEPanel.xaml"
            this.upButton.Click += new System.Windows.RoutedEventHandler(this.UpButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.downButton = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\View\IEPanel.xaml"
            this.downButton.Click += new System.Windows.RoutedEventHandler(this.DownButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

