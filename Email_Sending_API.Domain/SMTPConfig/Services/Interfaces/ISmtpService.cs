using Email_Sending_API.Domain.SMTPConfig.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Email_Sending_API.Domain.SMTPConfig.Services.Interfaces
{
    public interface ISmtpService
    {
        SMTPConfigModel GetSmtpClientFromConfig();
    }
}
