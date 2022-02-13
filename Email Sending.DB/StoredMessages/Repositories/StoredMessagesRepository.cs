using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Email_Sending_API.DB.StoredMessages.Models;
using Email_Sending_API.DB.StoredMessages.Repositories.Interfaces;
using Email_Sending_API.DB.Contexts;

namespace Email_Sending_API.DB.StoredMessages.Repositories
{
    public class StoredMessagesRepository : IStoredMessagesRepository
    {
        private readonly MailServiceDBContext _context;

        public StoredMessagesRepository(MailServiceDBContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Сохраняет сообщение в базе данных
        /// </summary>
        /// <param name="storedMessageDB">Сообщение</param>
        /// <returns></returns>
        public async Task SaveMessageAsync(StoredMessageDB storedMessageDB)
        {
            await _context.StoredMessagesDBs.AddAsync(storedMessageDB);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Получает список сообщений из базы данных
        /// </summary>
        /// <returns></returns>
        public async Task<List<StoredMessageDB>> GetMessagesAsync()
        {
            return await _context.StoredMessagesDBs.ToListAsync();
        }
    }
}
