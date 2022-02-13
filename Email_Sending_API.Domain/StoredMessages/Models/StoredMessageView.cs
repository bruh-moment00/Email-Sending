using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.StoredMessages.Models
{
    public class StoredMessageView
    {
        public StoredMessageView(int id, string recepientAddress, string subject, string body, DateTime creationTime, string result, string failedMessage)
        {
            ID = id;
            RecepientAddress = recepientAddress;
            Subject = subject;
            Body = body;
            CreationTime = creationTime;
            Result = result;
            FailedMessage = failedMessage;
        }
        /// <summary>
        /// Идентификатор сообщения в базе данных
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Адрес получателя
        /// </summary>
        public string RecepientAddress { get; set; }
        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Тело сообщения
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Дата и время написания
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// Результат отправки
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string FailedMessage { get; set; }
    }
}
