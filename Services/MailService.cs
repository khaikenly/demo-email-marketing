using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mail_marketing.Configuration;
using demo_mail_marketing.Data;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace demo_mail_marketing.Services
{
    public class MailService : IMailService
    {

        private readonly MailSettings _mailSettings;

        private readonly ILogger<MailService> _logger;

        public MailService (IOptions<MailSettings> mailSettings, ILogger<MailService> logger) {
            _mailSettings = mailSettings.Value;
            _logger = logger ;
        }

        public async Task<bool> SendAsync(MailContent mailContent)
        {
            try
            {
                var email = new MimeMessage();
                // Sender
                email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
                email.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);

                // Receiver
                foreach (string mailAddress in mailContent.To)
                    email.To.Add(MailboxAddress.Parse(mailAddress.Trim()));

                // BCC
                // Check if a BCC was supplied in the request
                if (mailContent.Bcc != null) {
                    // Get only addresses where value is not null or with whitespace. x = value of address
                    foreach (string mailAddress in mailContent.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        email.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }

                // CC
                // Check if a CC address was supplied in the request
                if (mailContent.Cc != null) {
                    foreach (string mailAddress in mailContent.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        email.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }

                // Add Content to Mime Message
                var body = new BodyBuilder();
                email.Subject = mailContent.Subject;
                body.HtmlBody = mailContent.Body;
                email.Body = body.ToMessageBody();

                // Send Email
                using var smtp = new SmtpClient();
                if (_mailSettings.UseSSL) {
                    await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.SslOnConnect);
                }
                else if (_mailSettings.UseStartTls) {
                    await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                }

                await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}