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
        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Тело сообщения
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Список получателей
        /// </summary>
        public List<string> Recepients { get; set; }
    }
}
