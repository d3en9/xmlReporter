using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace xmlStorage.xmlConverterToJson
{
    public class XsdRule : IRule
    {

        public XsdRule(XmlReader xsltReader)
        {
            this.xsltReader = xsltReader;
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
