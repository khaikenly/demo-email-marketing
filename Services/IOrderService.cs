using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mail_marketing.Services
{
    public interface IOrderService
    {
        Task<bool> SendOrderConfirmationEmail(List<string> email);
    }
}