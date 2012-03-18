using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace xmlStorage.xmlConverterToJson
{
    public interface IXmlConverter
    {
        string Convert(StringReader reader);
        string Convert(string fileName);
        xmlConverterRulesCollection Rules { get; set; }
        void Configure();
    }
}
