using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mail_marketing.Models;
using Microsoft.AspNetCore.Mvc;

namespace demo_mail_marketing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        // create order
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderModel orderModel)
        {
            return Ok("Success to create order");
        }
    }
}