using System;
using System.Collections.Generic;

#nullable disable

namespace Email_Sending_API.DB.StoredMessages.Models
{
    public partial class StoredMessageDB
    {
        /// <summary>
        /// Идентификатор сообщения в базе данных
        /// </summary>
        public int Id { get; set; }
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
        public int Result { get; set; }
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string FailedMessage { get; set; }
    }
}
