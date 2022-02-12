using Email_Sending_API.Domain.StoredMessages.Models;
using Jane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.StoredMessages.Services.Interfaces
{
    interface ISenderService
    {
        Task<IResult> SendMessage(StoredMessage message);
    }
}
