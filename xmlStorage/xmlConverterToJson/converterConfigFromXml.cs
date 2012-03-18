using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace xmlStorage.xmlConverterToJson
{
    class converterConfigFromXml 
    {
        private string xmlFileConfigName = "xmlConverter.config";
        private static IXmlConverter converter;

        public static void Configure(IXmlConverter converter)
        {
            converterConfigFromXml.converter = converter;
            converter.Rules = new xmlConverterRulesCollection();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            XmlReader reader = XmlReader.Create(new StringReader(Properties.Resources.xmlConverter), settings);
            while (reader.Read())
            {
                Debug.Print(reader.LocalName);
                if (reader.LocalName == "rule" && reader.GetAttribute("type") == "RootTagRule")
                    readRootTagRule(reader);
            }
        }

        private static void readRootTagRule(XmlReader reader)
        {
            reader.Read(); reader.Read();
            string tagName = reader.Value;
            reader.Read(); reader.Read(); reader.Read();
            string xsltFileName = reader.Value;
            converter.Rules.rootTagRule = new RootTagRule(tagName);
            //close tag
            reader.Read();
            reader.Read();

        }
    }
}
