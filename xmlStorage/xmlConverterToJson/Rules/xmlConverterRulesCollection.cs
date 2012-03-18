using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xmlStorage.xmlConverterToJson
{
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
}
