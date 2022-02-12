using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Email_Sending_API.DB.StoredMessages.Models;

#nullable disable

namespace Email_Sending_API.DB.Contexts
{
    public partial class MailServiceDBContext : DbContext
    {
        protected readonly string ConnectionString;
        public MailServiceDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public MailServiceDBContext(DbContextOptions<MailServiceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StoredMessageDB> StoredMessagesDBs { get; set; }

    }
}
