using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationMongo
{
    class User
    {
        public string Id { get; set;}
        public string FIO { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
