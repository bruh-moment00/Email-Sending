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
    class MessageService : IMessageService
    {
        private readonly IStoredMessagesRepository _storedMessagesRepository;
        private readonly SenderService _senderService;

        public MessageService(IStoredMessagesRepository storedMessagesRepository, SenderService senderService)
        {
            _storedMessagesRepository = storedMessagesRepository;
            _senderService = senderService;
        }
        public async Task<IResult<IEnumerable<StoredMessage>>> GetStoredMessagesAsync()
        {
            IEnumerable<StoredMessageDB> storedMessageDBs = await _storedMessagesRepository.GetMessagesAsync();

            return Result.Success(storedMessageDBs.ToStoredMessages());
        }

        public async Task<IResult> SendAndSaveMessage(StoredMessage message)
        {
            Result sendResult = (Result)await _senderService.SendMessage(message);

            if (sendResult.Ok)
            {
                message.Result = ResultEnum.OK;
            }
            else
            {
                message.Result = ResultEnum.Failed;
                message.FailedMessage = sendResult.Reason;
            }

            await _storedMessagesRepository.SaveMessageAsync(message.ToStoredMessageDB());
            return Result.Success();
        }
    }
}
