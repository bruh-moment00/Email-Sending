using Email_Sending_API.Domain.StoredMessages.Models;
using Jane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Email_Sending_API.DB.StoredMessages.Repositories.Interfaces;

namespace Email_Sending_API.Domain.StoredMessages.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IResult<IEnumerable<StoredMessage>>> GetStoredMessagesAsync();
        Task<IResult> SendAndSaveMessage(StoredMessage message);
    }
}
