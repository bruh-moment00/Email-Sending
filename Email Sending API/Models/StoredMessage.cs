using System;
using System.Collections.Generic;

#nullable disable

namespace Email_Sending_API.Models
{
    public partial class StoredMessage
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreationTime { get; set; }
        public bool Result { get; set; }
        public string FailedMessage { get; set; }
    }
}
