using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace xmlStorage
{
    public interface IXmlConverter
    {
        string Convert(StringReader reader);
        string Convert(string fileName);
    }

    public interface IRule
    {
        bool IsTrue(XmlReader reader);
        IRule IfTrue { get; set; }
        IRule IfFalse { get; set; }
        XmlReader xsltReader { get; set; }
    }

    public class xmlConverterToJsonString : IXmlConverter
    {
        public string Convert(StringReader reader)
        {
            XmlReader xmlReader = XmlReader.Create(reader);
            return null;
        }
        public string Convert(string fileName)
        {
            throw new NotImplementedException("Not implemented method");
        }


    }

    public class xmlConverterRulesCollection //: ICollection <IRule>
    {
        public RootTagRule rootTagRule { get; set; }
        List<IRule> Rules;
        int Count 
        {
            get
            {
                return 0;
            }
        }
        
        bool IsReadOnly 
        {
            get
            {
                return false;
            }
        }

        void Add(IRule item)
        {
            Rules.Add(item);
        }

        void Clear()
        {
            Rules.Clear();
            rootTagRule = null;
        }

        bool Contains(IRule item)
        {
            return Rules.Contains(item) || item.Equals(rootTagRule);
        }

        void CopyTo(IRule[] array, int arrayIndex)
        {

        }

        bool Remove(IRule item)
        {
            return Rules.Remove(item);
        }

    }

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
