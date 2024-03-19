using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mail_marketing.Data;

namespace demo_mail_marketing.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMailService _mailService;

        public OrderService(IMailService mailService)
        { 
            _mailService = mailService;
        }

        public async Task<bool> SendOrderConfirmationEmail(List<string> email)
        {
            var mailContent = new MailContent(email, "Order Confirmation", "Your order has been confirmed. Thank you for your purchase.");

            return await _mailService.SendAsync(mailContent);
        }
    }
}