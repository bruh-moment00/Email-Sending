using Email_Sending_API.Domain.StoredMessages.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.StoredMessages.Models
{
    public class QueryMessage
    {
        public List<string> RecepientsAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
