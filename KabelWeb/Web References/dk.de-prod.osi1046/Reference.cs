﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace KabelWeb.dk.de_prod.osi1046 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    // CODEGEN: The optional WSDL extension element 'PolicyReference' from namespace 'http://schemas.xmlsoap.org/ws/2004/09/policy' was not handled.
    // CODEGEN: The optional WSDL extension element 'EndpointReference' from namespace 'http://www.w3.org/2005/08/addressing' was not handled.
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="CustomBinding_ServiceProxy", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FaultInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NotificationDocumentBase))]
    public partial class ServiceProxy : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CreateNotificationOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServiceProxy() {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = global::KabelWeb.Properties.Settings.Default.KabelWeb_dk_de_prod_osi1046_ServiceProxy;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event CreateNotificationCompletedEventHandler CreateNotificationCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:ServiceProxy/CreateNotification", RequestNamespace="", ResponseNamespace="", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public NotificationResult CreateNotification([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] NotificationDocument notificationDocument) {
            object[] results = this.Invoke("CreateNotification", new object[] {
                        notificationDocument});
            return ((NotificationResult)(results[0]));
        }
        
        /// <remarks/>
        public void CreateNotificationAsync(NotificationDocument notificationDocument) {
            this.CreateNotificationAsync(notificationDocument, null);
        }
        
        /// <remarks/>
        public void CreateNotificationAsync(NotificationDocument notificationDocument, object userState) {
            if ((this.CreateNotificationOperationCompleted == null)) {
                this.CreateNotificationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateNotificationOperationCompleted);
            }
            this.InvokeAsync("CreateNotification", new object[] {
                        notificationDocument}, this.CreateNotificationOperationCompleted, userState);
        }
        
        private void OnCreateNotificationOperationCompleted(object arg) {
            if ((this.CreateNotificationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateNotificationCompleted(this, new CreateNotificationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public partial class NotificationDocument : NotificationDocumentBase {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NotificationBorgerDocument))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NotificationDocument))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public partial class NotificationDocumentBase {
        
        private SmlUserProfile createdByProfileField;
        
        private bool createdByProfileFieldSpecified;
        
        private string createdByUserField;
        
        private int gisObjIdField;
        
        private bool gisObjIdFieldSpecified;
        
        private NotificationPriority jobCodePriorityField;
        
        private bool jobCodePriorityFieldSpecified;
        
        private string notifyMailAddressField;
        
        private string notifyNameField;
        
        private string notifyPhoneNoField;
        
        private SapObjectType objectTypeField;
        
        private bool objectTypeFieldSpecified;
        
        private string partner2NrField;
        
        private Point pointField;
        
        private string remarkField;
        
        private string responsibleAddressField;
        
        private string responsibleCarRegField;
        
        private string responsibleNameField;
        
        private string responsiblePhoneNoField;
        
        private string sapObjIdField;
        
        private string sapQmnumField;
        
        private string smlNotifNrField;
        
        private NotificationType smlNotificationTypeField;
        
        private bool smlNotificationTypeFieldSpecified;
        
        private string smlRefToField;
        
        private System.Nullable<System.DateTime> timeClosedField;
        
        private bool timeClosedFieldSpecified;
        
        private System.DateTime timeCreatedField;
        
        private bool timeCreatedFieldSpecified;
        
        private System.Nullable<System.DateTime> timeLastEditedField;
        
        private bool timeLastEditedFieldSpecified;
        
        private System.DateTime timeStartedField;
        
        private bool timeStartedFieldSpecified;
        
        /// <remarks/>
        public SmlUserProfile CreatedByProfile {
            get {
                return this.createdByProfileField;
            }
            set {
                this.createdByProfileField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreatedByProfileSpecified {
            get {
                return this.createdByProfileFieldSpecified;
            }
            set {
                this.createdByProfileFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CreatedByUser {
            get {
                return this.createdByUserField;
            }
            set {
                this.createdByUserField = value;
            }
        }
        
        /// <remarks/>
        public int GisObjId {
            get {
                return this.gisObjIdField;
            }
            set {
                this.gisObjIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GisObjIdSpecified {
            get {
                return this.gisObjIdFieldSpecified;
            }
            set {
                this.gisObjIdFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public NotificationPriority JobCodePriority {
            get {
                return this.jobCodePriorityField;
            }
            set {
                this.jobCodePriorityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool JobCodePrioritySpecified {
            get {
                return this.jobCodePriorityFieldSpecified;
            }
            set {
                this.jobCodePriorityFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string NotifyMailAddress {
            get {
                return this.notifyMailAddressField;
            }
            set {
                this.notifyMailAddressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string NotifyName {
            get {
                return this.notifyNameField;
            }
            set {
                this.notifyNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string NotifyPhoneNo {
            get {
                return this.notifyPhoneNoField;
            }
            set {
                this.notifyPhoneNoField = value;
            }
        }
        
        /// <remarks/>
        public SapObjectType ObjectType {
            get {
                return this.objectTypeField;
            }
            set {
                this.objectTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ObjectTypeSpecified {
            get {
                return this.objectTypeFieldSpecified;
            }
            set {
                this.objectTypeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Partner2Nr {
            get {
                return this.partner2NrField;
            }
            set {
                this.partner2NrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Point Point {
            get {
                return this.pointField;
            }
            set {
                this.pointField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Remark {
            get {
                return this.remarkField;
            }
            set {
                this.remarkField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ResponsibleAddress {
            get {
                return this.responsibleAddressField;
            }
            set {
                this.responsibleAddressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ResponsibleCarReg {
            get {
                return this.responsibleCarRegField;
            }
            set {
                this.responsibleCarRegField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ResponsibleName {
            get {
                return this.responsibleNameField;
            }
            set {
                this.responsibleNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ResponsiblePhoneNo {
            get {
                return this.responsiblePhoneNoField;
            }
            set {
                this.responsiblePhoneNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string SapObjId {
            get {
                return this.sapObjIdField;
            }
            set {
                this.sapObjIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string SapQmnum {
            get {
                return this.sapQmnumField;
            }
            set {
                this.sapQmnumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string SmlNotifNr {
            get {
                return this.smlNotifNrField;
            }
            set {
                this.smlNotifNrField = value;
            }
        }
        
        /// <remarks/>
        public NotificationType SmlNotificationType {
            get {
                return this.smlNotificationTypeField;
            }
            set {
                this.smlNotificationTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SmlNotificationTypeSpecified {
            get {
                return this.smlNotificationTypeFieldSpecified;
            }
            set {
                this.smlNotificationTypeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string SmlRefTo {
            get {
                return this.smlRefToField;
            }
            set {
                this.smlRefToField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> TimeClosed {
            get {
                return this.timeClosedField;
            }
            set {
                this.timeClosedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TimeClosedSpecified {
            get {
                return this.timeClosedFieldSpecified;
            }
            set {
                this.timeClosedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime TimeCreated {
            get {
                return this.timeCreatedField;
            }
            set {
                this.timeCreatedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TimeCreatedSpecified {
            get {
                return this.timeCreatedFieldSpecified;
            }
            set {
                this.timeCreatedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> TimeLastEdited {
            get {
                return this.timeLastEditedField;
            }
            set {
                this.timeLastEditedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TimeLastEditedSpecified {
            get {
                return this.timeLastEditedFieldSpecified;
            }
            set {
                this.timeLastEditedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime TimeStarted {
            get {
                return this.timeStartedField;
            }
            set {
                this.timeStartedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TimeStartedSpecified {
            get {
                return this.timeStartedFieldSpecified;
            }
            set {
                this.timeStartedFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public enum SmlUserProfile {
        
        /// <remarks/>
        C,
        
        /// <remarks/>
        I,
        
        /// <remarks/>
        K,
        
        /// <remarks/>
        P,
        
        /// <remarks/>
        S,
        
        /// <remarks/>
        T,
        
        /// <remarks/>
        U,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public enum NotificationPriority {
        
        /// <remarks/>
        Low,
        
        /// <remarks/>
        Normal,
        
        /// <remarks/>
        High,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public enum SapObjectType {
        
        /// <remarks/>
        TA4,
        
        /// <remarks/>
        CU,
        
        /// <remarks/>
        LYG,
        
        /// <remarks/>
        STR,
        
        /// <remarks/>
        TAE,
        
        /// <remarks/>
        TA3,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public partial class Point {
        
        private double xField;
        
        private double yField;
        
        /// <remarks/>
        public double X {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }
        
        /// <remarks/>
        public double Y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NotificationResult))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NotificationDocumentResult))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public partial class FaultInfo {
        
        private string[] errorsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] Errors {
            get {
                return this.errorsField;
            }
            set {
                this.errorsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NotificationDocumentResult))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public partial class NotificationResult : FaultInfo {
        
        private bool operationCompletedField;
        
        private bool operationCompletedFieldSpecified;
        
        /// <remarks/>
        public bool OperationCompleted {
            get {
                return this.operationCompletedField;
            }
            set {
                this.operationCompletedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OperationCompletedSpecified {
            get {
                return this.operationCompletedFieldSpecified;
            }
            set {
                this.operationCompletedFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public partial class NotificationDocumentResult : NotificationResult {
        
        private NotificationBorgerDocument notificationBorgerDocumentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public NotificationBorgerDocument NotificationBorgerDocument {
            get {
                return this.notificationBorgerDocumentField;
            }
            set {
                this.notificationBorgerDocumentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public partial class NotificationBorgerDocument : NotificationDocumentBase {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/InformiGIS.SML.Services")]
    public enum NotificationType {
        
        /// <remarks/>
        I,
        
        /// <remarks/>
        S,
        
        /// <remarks/>
        C,
        
        /// <remarks/>
        P,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CreateNotificationCompletedEventHandler(object sender, CreateNotificationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateNotificationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateNotificationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public NotificationResult Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((NotificationResult)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591