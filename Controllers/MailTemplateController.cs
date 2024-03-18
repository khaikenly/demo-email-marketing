using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using demo_mail_marketing.Data;
using demo_mail_marketing.IRepositories;
using demo_mail_marketing.Models;
using Microsoft.AspNetCore.Mvc;

namespace demo_mail_marketing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailTemplateController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly ILogger<MailTemplateController> _logger;
        private readonly IMailTemplateRepository _mailTemplateRepository;

        public MailTemplateController(ILogger<MailTemplateController> logger, IMailTemplateRepository mailTemplateRepository, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _mailTemplateRepository = mailTemplateRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MailTemplateModel>>> GetAllMailTemplates()
        {
            var MailTemplates = await _mailTemplateRepository.GetAllMailTemplatesAsync();
            var MailTemplateResources = _mapper.Map<IEnumerable<MailTemplate>, IEnumerable<MailTemplateModel>>(MailTemplates);

            return Ok(MailTemplateResources);
        }

        // create a new mail template
        [HttpPost("")]
        public async Task<ActionResult<MailTemplateModel>> CreateMailTemplate([FromForm] MailTemplateModel MailTemplateModel)
        {
                var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            
            var id = await _mailTemplateRepository.CreateMailTemplateAsync(MailTemplateModel);

                return Ok(JsonSerializer.Serialize(new
            {
                data = new
                {
                    id = id
                }
            }, options));
        }
    }
}