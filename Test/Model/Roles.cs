using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Model
{
    public class Roles
    {
        public string Role_Type { get; set; }
        public bool IsActive { get; set; }
        public DateTime timeStamp { get; set; }
        public long? Role_ID { get; set; }
        public long? myID { get; set; }
        public long? test2_ID { get; set; }
    }
}