using Email_Sending_API.Domain.SMTPConfig.Models;
using Email_Sending_API.Domain.SMTPConfig.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.SMTPConfig.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly SMTPConfigModel _options;
        public SmtpService(IOptions<SMTPConfigModel> options)
        {
            _options = options.Value;
        }
        public SMTPConfigModel GetSmtpClientFromConfig()
        {
            return _options;
        }
    }
}
