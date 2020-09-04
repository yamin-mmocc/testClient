using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Model
{
    public class Cards
    {
        public string Card_Type { get; set; }
        public string Card_Style { get; set; }
        public bool IsActive { get; set; }
        public DateTime timeStamp { get; set; }
        public long Card_ID { get; set; }
    }
}