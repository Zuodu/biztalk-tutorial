namespace Formation.Schema {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://Formation.Schema.OrderSAP",@"Order")]
    [Microsoft.XLANGs.BaseTypes.PropertyAttribute(typeof(global::Formation.Schema.OrderId), XPath = @"/*[local-name()='Order' and namespace-uri()='http://Formation.Schema.OrderSAP']/*[local-name()='OrderId' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.PropertyAttribute(typeof(global::Formation.Schema.ClientName), XPath = @"/*[local-name()='Order' and namespace-uri()='http://Formation.Schema.OrderSAP']/*[local-name()='Client' and namespace-uri()='http://Formation.Schema.ClientSAP']/*[local-name()='SurName' and namespace-uri()='']", XsdType = @"string")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Order"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Formation.Schema.ClientSAP", typeof(global::Formation.Schema.ClientSAP))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Formation.Schema.OrderProperty", typeof(global::Formation.Schema.OrderProperty))]
    public sealed class OrderSAP : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://Formation.Schema.OrderSAP"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns0=""https://Formation.Schema.OrderProperty"" xmlns:client=""http://Formation.Schema.ClientSAP"" targetNamespace=""http://Formation.Schema.OrderSAP"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""Formation.Schema.ClientSAP"" namespace=""http://Formation.Schema.ClientSAP"" />
  <xs:annotation>
    <xs:appinfo>
      <b:references>
        <b:reference targetNamespace=""http://Formation.Schema.ClientSAP"" />
      </b:references>
      <b:imports>
        <b:namespace prefix=""ns0"" uri=""https://Formation.Schema.OrderProperty"" location=""Formation.Schema.OrderProperty"" />
      </b:imports>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""Order"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property name=""ns0:OrderId"" xpath=""/*[local-name()='Order' and namespace-uri()='http://Formation.Schema.OrderSAP']/*[local-name()='OrderId' and namespace-uri()='']"" />
          <b:property name=""ns0:ClientName"" xpath=""/*[local-name()='Order' and namespace-uri()='http://Formation.Schema.OrderSAP']/*[local-name()='Client' and namespace-uri()='http://Formation.Schema.ClientSAP']/*[local-name()='SurName' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""OrderId"" type=""xs:string"" />
        <xs:element name=""Amount"" type=""xs:string"" />
        <xs:element ref=""client:Client"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public OrderSAP() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Order";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
