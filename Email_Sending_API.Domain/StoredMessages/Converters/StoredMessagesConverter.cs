﻿using Email_Sending_API.DB.StoredMessages.Models;
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
        public static StoredMessageDB ToStoredMessageDB (this StoredMessage storedMessage)
        {
            StoredMessageDB storedMessageDB = new StoredMessageDB
            {
                RecepientAddress = storedMessage.RecepientAddress,
                Subject = storedMessage.Subject,
                Body = storedMessage.Body,
                CreationTime = storedMessage.CreationTime,
                Result = storedMessage.Result == SendResult.OK,
                FailedMessage = storedMessage.FailedMessage
            };

            return storedMessageDB;
        }

        public static StoredMessage ToStoredMessage(this StoredMessageDB storedMessageDB)
        {
            StoredMessage storedMessage = new StoredMessage(
                storedMessageDB.Id,
                storedMessageDB.RecepientAddress,
                storedMessageDB.Subject,
                storedMessageDB.Body,
                storedMessageDB.CreationTime,
                (SendResult)Convert.ToInt32(storedMessageDB.Result),
                storedMessageDB.FailedMessage);

            return storedMessage;
        }

        public static IEnumerable<StoredMessage> ToStoredMessages(this IEnumerable<StoredMessageDB> storedMessageDBs)
        {
            IEnumerable<StoredMessage> storedMessages = storedMessageDBs.Select(ToStoredMessage);

            return storedMessages;
        }

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

        public static IEnumerable<StoredMessageView> ToStoredMessagesView(this IEnumerable<StoredMessage> storedMessages)
        {
            IEnumerable<StoredMessageView> storedMessagesView = storedMessages.Select(ToStoredMessageView);

            return storedMessagesView;
        }

        public static IEnumerable<StoredMessageView> ToStoredMessagesView(this IEnumerable<StoredMessageDB> storedMessagesDB)
        {
            IEnumerable<StoredMessageView> storedMessagesView = storedMessagesDB.ToStoredMessages().ToStoredMessagesView();

            return storedMessagesView;
        }
    }
}
