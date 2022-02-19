using Email_Sending_API.DB.StoredMessages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.DB.StoredMessages.Repositories.Interfaces
{
    public interface IStoredMessagesRepository : IDisposable
    {
        Task SaveMessageAsync(StoredMessageDB storedMessage);
        Task<List<StoredMessageDB>> GetMessagesAsync();
    }
}
