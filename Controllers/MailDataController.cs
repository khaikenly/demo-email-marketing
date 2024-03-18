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
    public class MailDataController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<MailDataController> _logger;
        private readonly IMailDataRepository _mailDataRepository;

        public MailDataController(ILogger<MailDataController> logger, IMailDataRepository mailDataRepository, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _mailDataRepository = mailDataRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MailDataModel>>> GetAllMailDatas()
        {
            var mailDatas = await _mailDataRepository.GetAllMailDatasAsync();
            var mailDataResources = _mapper.Map<IEnumerable<MailData>, IEnumerable<MailDataModel>>(mailDatas);

            return Ok(mailDataResources);
        }

        // // create mail data
        // [HttpPost("")]
        // public async Task<ActionResult<MailDataModel>> CreateMailData([FromBody] MailDataModel mailDataModel)
        // {
        //     var options = new JsonSerializerOptions
        //     {
        //         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        //         WriteIndented = true
        //     };
            
        //     var id = await _mailDataRepository.CreateMailDataAsync(mailDataModel);

        //     return Ok(JsonSerializer.Serialize(new
        //     {
        //         data = new
        //         {
        //             id = id
        //         }
        //     }, options));
        // }
    }
}