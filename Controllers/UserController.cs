using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);

            return Ok(userResources);
        }
    }
}