using Email_Sending_API.DB.StoredMessages.Models;
using Email_Sending_API.Domain.StoredMessages.Enums;
using Email_Sending_API.Domain.StoredMessages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.StoredMessages.Converters
{
    public static class StoredMessagesConverter
    {
        /// <summary>
        /// Преобразование сообщения в формат для базы данных
        /// </summary>
        /// <param name="storedMessage">Сообщение в общем формате</param>
        /// <returns></returns>
        public static StoredMessageDB ToStoredMessageDB (this StoredMessage storedMessage)
        {
            StoredMessageDB storedMessageDB = new StoredMessageDB
            {
                RecepientAddress = storedMessage.RecepientAddress,
                Subject = storedMessage.Subject,
                Body = storedMessage.Body,
                CreationTime = storedMessage.CreationTime,
                Result = (int)storedMessage.Result,
                FailedMessage = storedMessage.FailedMessage
            };

            return storedMessageDB;
        }

        /// <summary>
        /// Преобразует сообщение в общий формат
        /// </summary>
        /// <param name="storedMessageDB">Сообщение в формате базы данных</param>
        /// <returns></returns>
        public static StoredMessage ToStoredMessage(this StoredMessageDB storedMessageDB)
        {
            StoredMessage storedMessage = new StoredMessage(
                storedMessageDB.Id,
                storedMessageDB.RecepientAddress,
                storedMessageDB.Subject,
                storedMessageDB.Body,
                storedMessageDB.CreationTime,
                (SendResult)storedMessageDB.Result,
                storedMessageDB.FailedMessage);

            return storedMessage;
        }

        /// <summary>
        /// Преобразует список сообщений в список сообщений общего формата
        /// </summary>
        /// <param name="storedMessageDBs">Список сообщений в формате базы данных</param>
        /// <returns></returns>
        public static IEnumerable<StoredMessage> ToStoredMessages(this IEnumerable<StoredMessageDB> storedMessageDBs)
        {
            IEnumerable<StoredMessage> storedMessages = storedMessageDBs.Select(ToStoredMessage);

            return storedMessages;
        }

        /// <summary>
        /// Преобразует запрос в список сообщений общего формата
        /// </summary>
        /// <param name="queryMessage">Сообщение в формате запроса</param>
        /// <returns></returns>
        public static IEnumerable<StoredMessage> ToStoredMessages(this QueryMessage queryMessage)
        {
            List<StoredMessage> storedMessages = new List<StoredMessage>();
            foreach(string address in queryMessage.Recepients)
            {
                storedMessages.Add(new StoredMessage
                {
                    RecepientAddress = address,
                    Subject = queryMessage.Subject,
                    Body = queryMessage.Body
                });
            }
            return storedMessages;
        }

        /// <summary>
        /// Преобразует сообщение в формат для вывода
        /// </summary>
        /// <param name="storedMessage">Сообщение в общем формате</param>
        /// <returns></returns>
        public static StoredMessageView ToStoredMessageView(this StoredMessage storedMessage)
        {
            StoredMessageView storedMessageView = new StoredMessageView(
                (int)storedMessage.ID,
                storedMessage.RecepientAddress,
                storedMessage.Subject,
                storedMessage.Body,
                storedMessage.CreationTime,
                storedMessage.Result.ToString(),
                storedMessage.FailedMessage);

            return storedMessageView;
        }

        /// <summary>
        /// Преобразует несколько сообщений в формат для вывода
        /// </summary>
        /// <param name="storedMessages">Список сообщений в общем формате</param>
        /// <returns></returns>
        public static IEnumerable<StoredMessageView> ToStoredMessagesView(this IEnumerable<StoredMessage> storedMessages)
        {
            IEnumerable<StoredMessageView> storedMessagesView = storedMessages.Select(ToStoredMessageView);

            return storedMessagesView;
        }

        /// <summary>
        /// Преобразует несколько сообщений в формат для вывода
        /// </summary>
        /// <param name="storedMessagesDB">Список сообщений в формате базы данных</param>
        /// <returns></returns>
        public static IEnumerable<StoredMessageView> ToStoredMessagesView(this IEnumerable<StoredMessageDB> storedMessagesDB)
        {
            IEnumerable<StoredMessageView> storedMessagesView = storedMessagesDB.ToStoredMessages().ToStoredMessagesView();

            return storedMessagesView;
        }
    }
}
