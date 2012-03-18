using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace xmlStorage.xmlConverterToJson
{
    public class RootTagRule : IRule
    {
        public string tagName { get; set; }
        public Dictionary<string, string> Attributes { get; set; }

        public RootTagRule(string tagName)
        {
            this.tagName = tagName;
        }

        public RootTagRule(string tagName, Dictionary<string, string> Attributes)
        {
            this.tagName = tagName;
            this.Attributes = Attributes;
        }

        public bool IsTrue(XmlReader reader)
        {
            throw new NotImplementedException("Not implemented method");
        }

        public IRule IfTrue { get; set; }
        public IRule IfFalse { get; set; }
        public XmlReader xsltReader { get; set; }
    }
}
