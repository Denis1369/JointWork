﻿#pragma checksum "..\..\..\..\View\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D1B9462B5CA6CFEFC017F78C0551D9797FA25137"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using dentistry;


namespace dentistry {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 62 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox code_manager_tb;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password_manager_pass1;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox password_manager_tb;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button enter_btn;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox password_chb;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/dentistry;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.code_manager_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\..\View\MainWindow.xaml"
            this.code_manager_tb.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.code_manager_tb_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\..\View\MainWindow.xaml"
            this.code_manager_tb.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.code_manager_tb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.password_manager_pass1 = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 77 "..\..\..\..\View\MainWindow.xaml"
            this.password_manager_pass1.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.password_manager_tb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.password_manager_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 88 "..\..\..\..\View\MainWindow.xaml"
            this.password_manager_tb.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.password_manager_tb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.enter_btn = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\..\View\MainWindow.xaml"
            this.enter_btn.Click += new System.Windows.RoutedEventHandler(this.enter_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.password_chb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 128 "..\..\..\..\View\MainWindow.xaml"
            this.password_chb.Checked += new System.Windows.RoutedEventHandler(this.password_chb_Checked);
            
            #line default
            #line hidden
            
            #line 128 "..\..\..\..\View\MainWindow.xaml"
            this.password_chb.Unchecked += new System.Windows.RoutedEventHandler(this.password_chb_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

