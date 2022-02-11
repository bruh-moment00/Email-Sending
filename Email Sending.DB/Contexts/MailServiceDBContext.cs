using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Email_Sending_API.DB.StoredMessages.Models;

#nullable disable

namespace Email_Sending_API.Context
{
    public partial class MailServiceDBContext : DbContext
    {
        protected readonly string ConnectionString;
        public MailServiceDBContext()
        {
        }

        public MailServiceDBContext(DbContextOptions<MailServiceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StoredMessageDB> StoredMessagesDBs { get; set; }

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
