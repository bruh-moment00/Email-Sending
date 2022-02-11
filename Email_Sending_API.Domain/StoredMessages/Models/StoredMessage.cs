using Email_Sending_API.Domain.StoredMessages.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.StoredMessages.Models
{
    public class StoredMessage
    {
        public StoredMessage()
        {
        }

        public StoredMessage(int? id, string recepientAddress, string subject, string body, DateTime creationTime, ResultEnum result, string failedMessage)
        {
            ID = id;
            RecepientAddress = recepientAddress;
            Subject = subject;
            Body = body;
            CreationTime = creationTime;
            Result = result;
            FailedMessage = failedMessage;
        }

        public int? ID { get; set; }
        public string RecepientAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreationTime { get; set; }
        public ResultEnum Result { get; set; }
        public string FailedMessage { get; set; }
    }
}
