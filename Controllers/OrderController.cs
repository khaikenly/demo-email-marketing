using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mail_marketing.Models;
using demo_mail_marketing.Services;
using Microsoft.AspNetCore.Mvc;

namespace demo_mail_marketing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        // order confirmation
        [HttpPost("order-confirmation")]
        public async Task<IActionResult> OrderConfirmationAsync([FromBody] OrderModel orderModel)
        {
            await _orderService.SendOrderConfirmationEmail(orderModel.Email);
            return Ok("Success to send order confirmation email");
        }
    }
}