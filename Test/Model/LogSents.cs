﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Model
{
    public class LogSents
    {
        public DateTime CreatedDateTime { get; set; }
        public string MessageText { get; set; }
        public long? SendLog_ID { get; set; }
        public long? Card_ID { get; set; }
        public int? Status_Code { get; set; }
        public long Message_ID { get; set; }
        public long? Sender_ID { get; set; }
        public long? Receiver_ID { get; set; }
    }
}