using Email_Sending_API.DB.StoredMessages.Models;
using Email_Sending_API.DB.StoredMessages.Repositories.Interfaces;
using Email_Sending_API.Domain.StoredMessages.Converters;
using Email_Sending_API.Domain.StoredMessages.Enums;
using Email_Sending_API.Domain.StoredMessages.Models;
using Email_Sending_API.Domain.StoredMessages.Services.Interfaces;
using Jane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.StoredMessages.Services
{
    public class MessageService : IMessageService
    {
        private readonly IStoredMessagesRepository _storedMessagesRepository;
        private readonly ISenderService _senderService;

        public MessageService(IStoredMessagesRepository storedMessagesRepository, ISenderService senderService)
        {
            _storedMessagesRepository = storedMessagesRepository;
            _senderService = senderService;
        }
        
        /// <summary>
        /// Получение списка сообщений из репозитория в формате для вывода
        /// </summary>
        /// <returns></returns>
        public async Task<IResult<IEnumerable<StoredMessageView>>> GetStoredMessagesViewAsync()
        {
            IEnumerable<StoredMessageDB> storedMessageDBs = await _storedMessagesRepository.GetMessagesAsync();

            return Result.Success(storedMessageDBs.ToStoredMessagesView());
        }

        /// <summary>
        /// Отправка и сохранение сообщения в базе данных
        /// </summary>
        /// <param name="message">Сообщение в общем формате</param>
        /// <returns></returns>
        public async Task<IResult> SendAndSaveMessageAsync(StoredMessage message)
        {
            Result sendResult = (Result)await _senderService.SendMessage(message);

            if (sendResult.Ok)
            {
                message.Result = SendResult.OK;
            }
            else
            {
                message.Result = SendResult.Failed;
                message.FailedMessage = sendResult.Reason;
            }

            message.CreationTime = DateTime.Now;

            await _storedMessagesRepository.SaveMessageAsync(message.ToStoredMessageDB());
            return Result.Success();
        }

        /// <summary>
        /// Отправка и сохранение в базе данных нескольких сообщений
        /// </summary>
        /// <param name="queryMessage">Сообщение в формате запроса</param>
        /// <returns></returns>
        public async Task<IResult> SendAndSaveMultipleMessagesAsync(QueryMessage queryMessage)
        {
            IEnumerable<StoredMessage> storedMessages = queryMessage.ToStoredMessages();

            foreach(StoredMessage storedMessage in storedMessages)
            {
                await SendAndSaveMessageAsync(storedMessage);
            }

            return Result.Success();
        }
    }
}
