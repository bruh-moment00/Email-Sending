using Email_Sending_API.DB.StoredMessages.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.DB.Contexts
{
    public class SQLServerDBContext: MailServiceDBContext
    {
        public SQLServerDBContext(string connectionString) : base(connectionString)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<StoredMessageDB>(entity =>
            {
                entity.ToTable("STORED_MESSAGES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RecepientAddress).HasColumnName("recepient_address");

                entity.Property(e => e.Body).HasColumnName("body");

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_time");

                entity.Property(e => e.FailedMessage).HasColumnName("failed_message");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.Subject).HasColumnName("subject");
            });
        }
    }
}
