﻿#pragma checksum "..\..\DepartmentsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CC8CFC88796FF80D41E3DB4F58CDFACB4D8F6A180C715AA5404460DB8009F82B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DocsVisionClient;
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


namespace DocsVisionClient {
    
    
    /// <summary>
    /// DepartmentsWindow
    /// </summary>
    public partial class DepartmentsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\DepartmentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgDepartments;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\DepartmentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDepartmentEdit;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\DepartmentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDepartmentNew;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\DepartmentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDepartmentDelete;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\DepartmentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDepartmentOperation;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\DepartmentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDenyOperation;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\DepartmentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDepartmentName;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\DepartmentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbxDepartmentMain;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\DepartmentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDepartmentComment;
        
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
            System.Uri resourceLocater = new System.Uri("/DocsVisionClient;component/departmentswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DepartmentsWindow.xaml"
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
            this.dgDepartments = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnDepartmentEdit = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.btnDepartmentNew = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.btnDepartmentDelete = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.btnDepartmentOperation = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.btnDenyOperation = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.tbDepartmentName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.cbxDepartmentMain = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.tbDepartmentComment = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

