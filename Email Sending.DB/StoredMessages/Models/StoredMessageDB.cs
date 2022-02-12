using System;
using System.Collections.Generic;

#nullable disable

namespace Email_Sending_API.DB.StoredMessages.Models
{
    public partial class StoredMessageDB
    {
        public int Id { get; set; }
        public string RecepientAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreationTime { get; set; }
        public int Result { get; set; }
        public string FailedMessage { get; set; }
    }
}
