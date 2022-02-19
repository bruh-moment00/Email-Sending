using Email_Sending_API.Domain.SMTPConfig.Models;
using Email_Sending_API.Domain.SMTPConfig.Services.Interfaces;
using Email_Sending_API.Domain.StoredMessages.Models;
using Email_Sending_API.Domain.StoredMessages.Services.Interfaces;
using Jane;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.StoredMessages.Services
{
    public class SenderService : ISenderService
    {
        private readonly ISmtpService _smtpService;
        public SenderService(ISmtpService smtpService)
        {
            _smtpService = smtpService;
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<IResult> SendMessageAsync(StoredMessage message)
        {
            SMTPConfigModel smtpConfig = _smtpService.GetSmtpClientFromConfig();

            SmtpClient smtpClient = new SmtpClient(smtpConfig.Host, smtpConfig.Port);
            smtpClient.Credentials = new NetworkCredential(smtpConfig.UserName, smtpConfig.Password);
            smtpClient.EnableSsl = true;

            MailAddress from = new MailAddress(smtpConfig.Address);
            MailAddress to = new MailAddress(message.RecepientAddress);

            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                return Result.Success();
            }

            catch(Exception ex)
            {
                return Result.Failure(ex);
            }
        }
    }
}
