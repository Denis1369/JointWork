﻿#pragma checksum "..\..\..\..\View\Appointment.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6AFCC09B87E46FDC13C14F3491C41BE0E7376140"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Dent.View;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Dent.View {
    
    
    /// <summary>
    /// Appointment
    /// </summary>
    public partial class Appointment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\..\View\Appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name_tb;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\View\Appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox email_tb;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\View\Appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\View\Appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox hours_cb;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\View\Appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minute_cb;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\View\Appointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button booking_btn;
        
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
            System.Uri resourceLocater = new System.Uri("/Dent;component/view/appointment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Appointment.xaml"
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
            
            #line 24 "..\..\..\..\View\Appointment.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.name_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 46 "..\..\..\..\View\Appointment.xaml"
            this.name_tb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.name_tb_TextChanged);
            
            #line default
            #line hidden
            
            #line 46 "..\..\..\..\View\Appointment.xaml"
            this.name_tb.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.name_tb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.email_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\..\View\Appointment.xaml"
            this.email_tb.LostFocus += new System.Windows.RoutedEventHandler(this.email_tb_LostFocus);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\..\View\Appointment.xaml"
            this.email_tb.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.email_tb_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\..\View\Appointment.xaml"
            this.email_tb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.email_tb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.datePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 61 "..\..\..\..\View\Appointment.xaml"
            this.datePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.datePicker_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.hours_cb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.minute_cb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.booking_btn = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\..\View\Appointment.xaml"
            this.booking_btn.Click += new System.Windows.RoutedEventHandler(this.booking_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

