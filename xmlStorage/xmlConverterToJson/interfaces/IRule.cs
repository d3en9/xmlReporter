using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace xmlStorage.xmlConverterToJson
{
    public interface IRule
    {
        bool IsTrue(XmlReader reader);
        IRule IfTrue { get; set; }
        IRule IfFalse { get; set; }
        XmlReader xsltReader { get; set; }
    }
}
