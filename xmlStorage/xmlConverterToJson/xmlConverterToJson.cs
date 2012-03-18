using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace xmlStorage.xmlConverterToJson
{
    
    

    public class xmlConverterToJsonString : IXmlConverter
    {
        public xmlConverterRulesCollection Rules { get; set; }
        public string Convert(StringReader reader)
        {
            XmlReader xmlReader = XmlReader.Create(reader);
            return null;
        }
        public string Convert(string fileName)
        {
            throw new NotImplementedException("Not implemented method");
        }
        public void Configure()
        {
            converterConfigFromXml.Configure(this);
        }
    }

    

}
