using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Model
{
    public class Departments
    {
        public long? Department_ID { get; set; }
        public string Department_Name { get; set; }       
        public bool IsActive { get; set; }
        public DateTime timeStamp { get; set; }
    }
}