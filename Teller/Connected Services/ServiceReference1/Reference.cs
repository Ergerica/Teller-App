﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Teller.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cliente", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Cliente : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string apellidoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cedulaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                if ((object.ReferenceEquals(this.nombreField, value) != true)) {
                    this.nombreField = value;
                    this.RaisePropertyChanged("nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string apellido {
            get {
                return this.apellidoField;
            }
            set {
                if ((object.ReferenceEquals(this.apellidoField, value) != true)) {
                    this.apellidoField = value;
                    this.RaisePropertyChanged("apellido");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string cedula {
            get {
                return this.cedulaField;
            }
            set {
                if ((object.ReferenceEquals(this.cedulaField, value) != true)) {
                    this.cedulaField = value;
                    this.RaisePropertyChanged("cedula");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.DepositoServiceSoap")]
    public interface DepositoServiceSoap {
        
        // CODEGEN: Generating message contract since element name cedula from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getCliente", ReplyAction="*")]
        Teller.ServiceReference1.getClienteResponse getCliente(Teller.ServiceReference1.getClienteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getCliente", ReplyAction="*")]
        System.Threading.Tasks.Task<Teller.ServiceReference1.getClienteResponse> getClienteAsync(Teller.ServiceReference1.getClienteRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getClienteRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getCliente", Namespace="http://tempuri.org/", Order=0)]
        public Teller.ServiceReference1.getClienteRequestBody Body;
        
        public getClienteRequest() {
        }
        
        public getClienteRequest(Teller.ServiceReference1.getClienteRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class getClienteRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cedula;
        
        public getClienteRequestBody() {
        }
        
        public getClienteRequestBody(string cedula) {
            this.cedula = cedula;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getClienteResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getClienteResponse", Namespace="http://tempuri.org/", Order=0)]
        public Teller.ServiceReference1.getClienteResponseBody Body;
        
        public getClienteResponse() {
        }
        
        public getClienteResponse(Teller.ServiceReference1.getClienteResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class getClienteResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Teller.ServiceReference1.Cliente getClienteResult;
        
        public getClienteResponseBody() {
        }
        
        public getClienteResponseBody(Teller.ServiceReference1.Cliente getClienteResult) {
            this.getClienteResult = getClienteResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DepositoServiceSoapChannel : Teller.ServiceReference1.DepositoServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DepositoServiceSoapClient : System.ServiceModel.ClientBase<Teller.ServiceReference1.DepositoServiceSoap>, Teller.ServiceReference1.DepositoServiceSoap {
        
        public DepositoServiceSoapClient() {
        }
        
        public DepositoServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DepositoServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DepositoServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DepositoServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Teller.ServiceReference1.getClienteResponse Teller.ServiceReference1.DepositoServiceSoap.getCliente(Teller.ServiceReference1.getClienteRequest request) {
            return base.Channel.getCliente(request);
        }
        
        public Teller.ServiceReference1.Cliente getCliente(string cedula) {
            Teller.ServiceReference1.getClienteRequest inValue = new Teller.ServiceReference1.getClienteRequest();
            inValue.Body = new Teller.ServiceReference1.getClienteRequestBody();
            inValue.Body.cedula = cedula;
            Teller.ServiceReference1.getClienteResponse retVal = ((Teller.ServiceReference1.DepositoServiceSoap)(this)).getCliente(inValue);
            return retVal.Body.getClienteResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Teller.ServiceReference1.getClienteResponse> Teller.ServiceReference1.DepositoServiceSoap.getClienteAsync(Teller.ServiceReference1.getClienteRequest request) {
            return base.Channel.getClienteAsync(request);
        }
        
        public System.Threading.Tasks.Task<Teller.ServiceReference1.getClienteResponse> getClienteAsync(string cedula) {
            Teller.ServiceReference1.getClienteRequest inValue = new Teller.ServiceReference1.getClienteRequest();
            inValue.Body = new Teller.ServiceReference1.getClienteRequestBody();
            inValue.Body.cedula = cedula;
            return ((Teller.ServiceReference1.DepositoServiceSoap)(this)).getClienteAsync(inValue);
        }
    }
}