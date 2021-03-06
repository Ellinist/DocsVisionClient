﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocsVisionClient.DocsVisionService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Departments", Namespace="http://schemas.datacontract.org/2004/07/DocsVisionWebSide.DocsVisionClasses")]
    [System.SerializableAttribute()]
    public partial class Departments : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentCommentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDDepartmentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool MainDepartmentFlagField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartmentComment {
            get {
                return this.DepartmentCommentField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentCommentField, value) != true)) {
                    this.DepartmentCommentField = value;
                    this.RaisePropertyChanged("DepartmentComment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartmentName {
            get {
                return this.DepartmentNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentNameField, value) != true)) {
                    this.DepartmentNameField = value;
                    this.RaisePropertyChanged("DepartmentName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IDDepartment {
            get {
                return this.IDDepartmentField;
            }
            set {
                if ((this.IDDepartmentField.Equals(value) != true)) {
                    this.IDDepartmentField = value;
                    this.RaisePropertyChanged("IDDepartment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool MainDepartmentFlag {
            get {
                return this.MainDepartmentFlagField;
            }
            set {
                if ((this.MainDepartmentFlagField.Equals(value) != true)) {
                    this.MainDepartmentFlagField = value;
                    this.RaisePropertyChanged("MainDepartmentFlag");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Letters", Namespace="http://schemas.datacontract.org/2004/07/DocsVisionWebSide.DocsVisionClasses")]
    [System.SerializableAttribute()]
    public partial class Letters : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDDepartmentLetterField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDLetterField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsLetterIncomingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LetterCommentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LetterContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LetterDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LetterFromField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LetterNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LetterRegisterDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LetterToField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LetterTopicField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IDDepartmentLetter {
            get {
                return this.IDDepartmentLetterField;
            }
            set {
                if ((this.IDDepartmentLetterField.Equals(value) != true)) {
                    this.IDDepartmentLetterField = value;
                    this.RaisePropertyChanged("IDDepartmentLetter");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IDLetter {
            get {
                return this.IDLetterField;
            }
            set {
                if ((this.IDLetterField.Equals(value) != true)) {
                    this.IDLetterField = value;
                    this.RaisePropertyChanged("IDLetter");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsLetterIncoming {
            get {
                return this.IsLetterIncomingField;
            }
            set {
                if ((this.IsLetterIncomingField.Equals(value) != true)) {
                    this.IsLetterIncomingField = value;
                    this.RaisePropertyChanged("IsLetterIncoming");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LetterComment {
            get {
                return this.LetterCommentField;
            }
            set {
                if ((object.ReferenceEquals(this.LetterCommentField, value) != true)) {
                    this.LetterCommentField = value;
                    this.RaisePropertyChanged("LetterComment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LetterContent {
            get {
                return this.LetterContentField;
            }
            set {
                if ((object.ReferenceEquals(this.LetterContentField, value) != true)) {
                    this.LetterContentField = value;
                    this.RaisePropertyChanged("LetterContent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LetterDateTime {
            get {
                return this.LetterDateTimeField;
            }
            set {
                if ((this.LetterDateTimeField.Equals(value) != true)) {
                    this.LetterDateTimeField = value;
                    this.RaisePropertyChanged("LetterDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LetterFrom {
            get {
                return this.LetterFromField;
            }
            set {
                if ((object.ReferenceEquals(this.LetterFromField, value) != true)) {
                    this.LetterFromField = value;
                    this.RaisePropertyChanged("LetterFrom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LetterName {
            get {
                return this.LetterNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LetterNameField, value) != true)) {
                    this.LetterNameField = value;
                    this.RaisePropertyChanged("LetterName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LetterRegisterDateTime {
            get {
                return this.LetterRegisterDateTimeField;
            }
            set {
                if ((this.LetterRegisterDateTimeField.Equals(value) != true)) {
                    this.LetterRegisterDateTimeField = value;
                    this.RaisePropertyChanged("LetterRegisterDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LetterTo {
            get {
                return this.LetterToField;
            }
            set {
                if ((object.ReferenceEquals(this.LetterToField, value) != true)) {
                    this.LetterToField = value;
                    this.RaisePropertyChanged("LetterTo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LetterTopic {
            get {
                return this.LetterTopicField;
            }
            set {
                if ((object.ReferenceEquals(this.LetterTopicField, value) != true)) {
                    this.LetterTopicField = value;
                    this.RaisePropertyChanged("LetterTopic");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TagsOfLetter", Namespace="http://schemas.datacontract.org/2004/07/DocsVisionWebSide.DocsVisionClasses")]
    [System.SerializableAttribute()]
    public partial class TagsOfLetter : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDLetterLinkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDTagLinkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IDLetterLink {
            get {
                return this.IDLetterLinkField;
            }
            set {
                if ((this.IDLetterLinkField.Equals(value) != true)) {
                    this.IDLetterLinkField = value;
                    this.RaisePropertyChanged("IDLetterLink");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IDTagLink {
            get {
                return this.IDTagLinkField;
            }
            set {
                if ((this.IDTagLinkField.Equals(value) != true)) {
                    this.IDTagLinkField = value;
                    this.RaisePropertyChanged("IDTagLink");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TagName {
            get {
                return this.TagNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TagNameField, value) != true)) {
                    this.TagNameField = value;
                    this.RaisePropertyChanged("TagName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tags", Namespace="http://schemas.datacontract.org/2004/07/DocsVisionWebSide.DocsVisionClasses")]
    [System.SerializableAttribute()]
    public partial class Tags : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDTagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IDTag {
            get {
                return this.IDTagField;
            }
            set {
                if ((this.IDTagField.Equals(value) != true)) {
                    this.IDTagField = value;
                    this.RaisePropertyChanged("IDTag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TagName {
            get {
                return this.TagNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TagNameField, value) != true)) {
                    this.TagNameField = value;
                    this.RaisePropertyChanged("TagName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DocsVisionService.IDocsVisionService")]
    public interface IDocsVisionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/GetAllDepartments", ReplyAction="http://tempuri.org/IDocsVisionService/GetAllDepartmentsResponse")]
        System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Departments>, int> GetAllDepartments();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/GetAllDepartments", ReplyAction="http://tempuri.org/IDocsVisionService/GetAllDepartmentsResponse")]
        System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Departments>, int>> GetAllDepartmentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/AddNewDepartment", ReplyAction="http://tempuri.org/IDocsVisionService/AddNewDepartmentResponse")]
        int AddNewDepartment(string departmentName, string departmentComment, bool mainDepartmentFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/AddNewDepartment", ReplyAction="http://tempuri.org/IDocsVisionService/AddNewDepartmentResponse")]
        System.Threading.Tasks.Task<int> AddNewDepartmentAsync(string departmentName, string departmentComment, bool mainDepartmentFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/UpdateDepartment", ReplyAction="http://tempuri.org/IDocsVisionService/UpdateDepartmentResponse")]
        int UpdateDepartment(int idDepartment, string departmentName, string departmentComment, bool mainDepartmentFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/UpdateDepartment", ReplyAction="http://tempuri.org/IDocsVisionService/UpdateDepartmentResponse")]
        System.Threading.Tasks.Task<int> UpdateDepartmentAsync(int idDepartment, string departmentName, string departmentComment, bool mainDepartmentFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/DeleteDepartment", ReplyAction="http://tempuri.org/IDocsVisionService/DeleteDepartmentResponse")]
        int DeleteDepartment(int idDepartment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/DeleteDepartment", ReplyAction="http://tempuri.org/IDocsVisionService/DeleteDepartmentResponse")]
        System.Threading.Tasks.Task<int> DeleteDepartmentAsync(int idDepartment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/GetLetters", ReplyAction="http://tempuri.org/IDocsVisionService/GetLettersResponse")]
        System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Letters>, int> GetLetters(string whereParams);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/GetLetters", ReplyAction="http://tempuri.org/IDocsVisionService/GetLettersResponse")]
        System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Letters>, int>> GetLettersAsync(string whereParams);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/AddLetter", ReplyAction="http://tempuri.org/IDocsVisionService/AddLetterResponse")]
        System.Tuple<int, int> AddLetter(int idDepartmentLetter, string letterName, System.DateTime letterDateTime, string letterTopic, string letterFrom, string letterTo, string letterContent, string letterComment, bool isLetterIncoming, string whereCondition);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/AddLetter", ReplyAction="http://tempuri.org/IDocsVisionService/AddLetterResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, int>> AddLetterAsync(int idDepartmentLetter, string letterName, System.DateTime letterDateTime, string letterTopic, string letterFrom, string letterTo, string letterContent, string letterComment, bool isLetterIncoming, string whereCondition);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/DeleteLetter", ReplyAction="http://tempuri.org/IDocsVisionService/DeleteLetterResponse")]
        int DeleteLetter(int idLetter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/DeleteLetter", ReplyAction="http://tempuri.org/IDocsVisionService/DeleteLetterResponse")]
        System.Threading.Tasks.Task<int> DeleteLetterAsync(int idLetter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/EditLetter", ReplyAction="http://tempuri.org/IDocsVisionService/EditLetterResponse")]
        int EditLetter(int idLetter, int idDepartmentLetter, string letterName, System.DateTime letterDateTime, string letterTopic, string letterFrom, string letterTo, string letterContent, string letterComment, bool isLetterIncoming, string whereCondition);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/EditLetter", ReplyAction="http://tempuri.org/IDocsVisionService/EditLetterResponse")]
        System.Threading.Tasks.Task<int> EditLetterAsync(int idLetter, int idDepartmentLetter, string letterName, System.DateTime letterDateTime, string letterTopic, string letterFrom, string letterTo, string letterContent, string letterComment, bool isLetterIncoming, string whereCondition);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/GetTagsOfLetter", ReplyAction="http://tempuri.org/IDocsVisionService/GetTagsOfLetterResponse")]
        System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.TagsOfLetter>, int> GetTagsOfLetter(int idLetter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/GetTagsOfLetter", ReplyAction="http://tempuri.org/IDocsVisionService/GetTagsOfLetterResponse")]
        System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.TagsOfLetter>, int>> GetTagsOfLetterAsync(int idLetter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/UpdateTagsOfLetter", ReplyAction="http://tempuri.org/IDocsVisionService/UpdateTagsOfLetterResponse")]
        int UpdateTagsOfLetter(System.Collections.Generic.List<DocsVisionClient.DocsVisionService.TagsOfLetter> tagsOfLetterList, int idLetter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/UpdateTagsOfLetter", ReplyAction="http://tempuri.org/IDocsVisionService/UpdateTagsOfLetterResponse")]
        System.Threading.Tasks.Task<int> UpdateTagsOfLetterAsync(System.Collections.Generic.List<DocsVisionClient.DocsVisionService.TagsOfLetter> tagsOfLetterList, int idLetter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/GetTags", ReplyAction="http://tempuri.org/IDocsVisionService/GetTagsResponse")]
        System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Tags>, int> GetTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/GetTags", ReplyAction="http://tempuri.org/IDocsVisionService/GetTagsResponse")]
        System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Tags>, int>> GetTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/DeleteTag", ReplyAction="http://tempuri.org/IDocsVisionService/DeleteTagResponse")]
        int DeleteTag(int idTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/DeleteTag", ReplyAction="http://tempuri.org/IDocsVisionService/DeleteTagResponse")]
        System.Threading.Tasks.Task<int> DeleteTagAsync(int idTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/AddTag", ReplyAction="http://tempuri.org/IDocsVisionService/AddTagResponse")]
        int AddTag(string tag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/AddTag", ReplyAction="http://tempuri.org/IDocsVisionService/AddTagResponse")]
        System.Threading.Tasks.Task<int> AddTagAsync(string tag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/RenameTag", ReplyAction="http://tempuri.org/IDocsVisionService/RenameTagResponse")]
        int RenameTag(int idTag, string tag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDocsVisionService/RenameTag", ReplyAction="http://tempuri.org/IDocsVisionService/RenameTagResponse")]
        System.Threading.Tasks.Task<int> RenameTagAsync(int idTag, string tag);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDocsVisionServiceChannel : DocsVisionClient.DocsVisionService.IDocsVisionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DocsVisionServiceClient : System.ServiceModel.ClientBase<DocsVisionClient.DocsVisionService.IDocsVisionService>, DocsVisionClient.DocsVisionService.IDocsVisionService {
        
        public DocsVisionServiceClient() {
        }
        
        public DocsVisionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DocsVisionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DocsVisionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DocsVisionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Departments>, int> GetAllDepartments() {
            return base.Channel.GetAllDepartments();
        }
        
        public System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Departments>, int>> GetAllDepartmentsAsync() {
            return base.Channel.GetAllDepartmentsAsync();
        }
        
        public int AddNewDepartment(string departmentName, string departmentComment, bool mainDepartmentFlag) {
            return base.Channel.AddNewDepartment(departmentName, departmentComment, mainDepartmentFlag);
        }
        
        public System.Threading.Tasks.Task<int> AddNewDepartmentAsync(string departmentName, string departmentComment, bool mainDepartmentFlag) {
            return base.Channel.AddNewDepartmentAsync(departmentName, departmentComment, mainDepartmentFlag);
        }
        
        public int UpdateDepartment(int idDepartment, string departmentName, string departmentComment, bool mainDepartmentFlag) {
            return base.Channel.UpdateDepartment(idDepartment, departmentName, departmentComment, mainDepartmentFlag);
        }
        
        public System.Threading.Tasks.Task<int> UpdateDepartmentAsync(int idDepartment, string departmentName, string departmentComment, bool mainDepartmentFlag) {
            return base.Channel.UpdateDepartmentAsync(idDepartment, departmentName, departmentComment, mainDepartmentFlag);
        }
        
        public int DeleteDepartment(int idDepartment) {
            return base.Channel.DeleteDepartment(idDepartment);
        }
        
        public System.Threading.Tasks.Task<int> DeleteDepartmentAsync(int idDepartment) {
            return base.Channel.DeleteDepartmentAsync(idDepartment);
        }
        
        public System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Letters>, int> GetLetters(string whereParams) {
            return base.Channel.GetLetters(whereParams);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Letters>, int>> GetLettersAsync(string whereParams) {
            return base.Channel.GetLettersAsync(whereParams);
        }
        
        public System.Tuple<int, int> AddLetter(int idDepartmentLetter, string letterName, System.DateTime letterDateTime, string letterTopic, string letterFrom, string letterTo, string letterContent, string letterComment, bool isLetterIncoming, string whereCondition) {
            return base.Channel.AddLetter(idDepartmentLetter, letterName, letterDateTime, letterTopic, letterFrom, letterTo, letterContent, letterComment, isLetterIncoming, whereCondition);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, int>> AddLetterAsync(int idDepartmentLetter, string letterName, System.DateTime letterDateTime, string letterTopic, string letterFrom, string letterTo, string letterContent, string letterComment, bool isLetterIncoming, string whereCondition) {
            return base.Channel.AddLetterAsync(idDepartmentLetter, letterName, letterDateTime, letterTopic, letterFrom, letterTo, letterContent, letterComment, isLetterIncoming, whereCondition);
        }
        
        public int DeleteLetter(int idLetter) {
            return base.Channel.DeleteLetter(idLetter);
        }
        
        public System.Threading.Tasks.Task<int> DeleteLetterAsync(int idLetter) {
            return base.Channel.DeleteLetterAsync(idLetter);
        }
        
        public int EditLetter(int idLetter, int idDepartmentLetter, string letterName, System.DateTime letterDateTime, string letterTopic, string letterFrom, string letterTo, string letterContent, string letterComment, bool isLetterIncoming, string whereCondition) {
            return base.Channel.EditLetter(idLetter, idDepartmentLetter, letterName, letterDateTime, letterTopic, letterFrom, letterTo, letterContent, letterComment, isLetterIncoming, whereCondition);
        }
        
        public System.Threading.Tasks.Task<int> EditLetterAsync(int idLetter, int idDepartmentLetter, string letterName, System.DateTime letterDateTime, string letterTopic, string letterFrom, string letterTo, string letterContent, string letterComment, bool isLetterIncoming, string whereCondition) {
            return base.Channel.EditLetterAsync(idLetter, idDepartmentLetter, letterName, letterDateTime, letterTopic, letterFrom, letterTo, letterContent, letterComment, isLetterIncoming, whereCondition);
        }
        
        public System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.TagsOfLetter>, int> GetTagsOfLetter(int idLetter) {
            return base.Channel.GetTagsOfLetter(idLetter);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.TagsOfLetter>, int>> GetTagsOfLetterAsync(int idLetter) {
            return base.Channel.GetTagsOfLetterAsync(idLetter);
        }
        
        public int UpdateTagsOfLetter(System.Collections.Generic.List<DocsVisionClient.DocsVisionService.TagsOfLetter> tagsOfLetterList, int idLetter) {
            return base.Channel.UpdateTagsOfLetter(tagsOfLetterList, idLetter);
        }
        
        public System.Threading.Tasks.Task<int> UpdateTagsOfLetterAsync(System.Collections.Generic.List<DocsVisionClient.DocsVisionService.TagsOfLetter> tagsOfLetterList, int idLetter) {
            return base.Channel.UpdateTagsOfLetterAsync(tagsOfLetterList, idLetter);
        }
        
        public System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Tags>, int> GetTags() {
            return base.Channel.GetTags();
        }
        
        public System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<DocsVisionClient.DocsVisionService.Tags>, int>> GetTagsAsync() {
            return base.Channel.GetTagsAsync();
        }
        
        public int DeleteTag(int idTag) {
            return base.Channel.DeleteTag(idTag);
        }
        
        public System.Threading.Tasks.Task<int> DeleteTagAsync(int idTag) {
            return base.Channel.DeleteTagAsync(idTag);
        }
        
        public int AddTag(string tag) {
            return base.Channel.AddTag(tag);
        }
        
        public System.Threading.Tasks.Task<int> AddTagAsync(string tag) {
            return base.Channel.AddTagAsync(tag);
        }
        
        public int RenameTag(int idTag, string tag) {
            return base.Channel.RenameTag(idTag, tag);
        }
        
        public System.Threading.Tasks.Task<int> RenameTagAsync(int idTag, string tag) {
            return base.Channel.RenameTagAsync(idTag, tag);
        }
    }
}
