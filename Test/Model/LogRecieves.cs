﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Model
{
    public class LogRecieves
    {
        public DateTime CreatedDateTime { get; set; }
        public string replyMsg { get; set; }
        public long? ReceiveLog_ID { get; set; }
        public string MessageText { get; set; }
        public int? Status_Code { get; set; }

        public long? Card_ID { get; set; }


        public long? Sender_ID { get; set; }

        public long? Receiver_ID { get; set; }

    }
}