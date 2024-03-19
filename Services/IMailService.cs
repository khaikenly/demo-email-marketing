using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mail_marketing.Data;

namespace demo_mail_marketing.Services
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailContent mailContent);
    }
}