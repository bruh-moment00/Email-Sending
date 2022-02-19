using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Email_Sending_API.Domain.StoredMessages.Services;
using Email_Sending_API.Domain.StoredMessages.Services.Interfaces;
using Email_Sending_API.DB.StoredMessages.Repositories;
using Email_Sending_API.DB.StoredMessages.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Email_Sending_API.DB.Contexts;
using Email_Sending_API.Domain.SMTPConfig.Services;
using Email_Sending_API.Domain.SMTPConfig.Services.Interfaces;

namespace Email_Sending_API.IoC
{
    public class IoCContainer
    {
        /// <summary>
        /// Инициализация контейнера зависимостей
        /// </summary>
        /// <param name="container"></param>
        /// <param name="configuration"></param>
        public static void InitContainer(ContainerBuilder container, IConfiguration configuration)
        {
            container.RegisterType<MSSQLServerDBContext>().As<MailServiceDBContext>().WithParameter("connectionString", configuration["ConnectionStrings:MailServiceDB"]).InstancePerLifetimeScope();
            container.RegisterType<StoredMessagesRepository>().As<IStoredMessagesRepository>().InstancePerLifetimeScope();
            container.RegisterType<MessageService>().As<IMessageService>().SingleInstance();
            container.RegisterType<SenderService>().As<ISenderService>().SingleInstance();
            container.RegisterType<SmtpService>().As<ISmtpService>().SingleInstance();
        }
    }
}
