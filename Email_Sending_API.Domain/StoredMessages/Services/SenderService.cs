using Email_Sending_API.Domain.StoredMessages.Models;
using Email_Sending_API.Domain.StoredMessages.Services.Interfaces;
using Jane;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _senderConfiguration;
        public SenderService(IConfiguration configuration)
        {
            _senderConfiguration = configuration;
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<IResult> SendMessage(StoredMessage message)
        {
            MailAddress from = new MailAddress(_senderConfiguration["SMTPConfiguration:Address"]);
            MailAddress to = new MailAddress(message.RecepientAddress);

            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;

            SmtpClient smtpClient = new SmtpClient(_senderConfiguration["SMTPConfiguration:Host"], Convert.ToInt32(_senderConfiguration["Port"]));
            smtpClient.Credentials = new NetworkCredential(_senderConfiguration["SMTPConfiguration:Credentials:Login"], _senderConfiguration["SMTPConfiguration:Credentials:Password"]);
            smtpClient.EnableSsl = true;

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
