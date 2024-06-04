
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using Repositories;
using DTOs;
using AutoMapper;
using Entities;
using System.ComponentModel.DataAnnotations;
namespace projectWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService,IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            User user = await _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NoContent();
        }






        // POST: LoginController/Create
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login([FromBody] UserLoginDTO newUser)
        {
            
            _logger.LogInformation("Login attempeted with user name {0}  and password {1}", newUser.Email, newUser.Password);
            User user = _mapper.Map<UserLoginDTO, User>(newUser);
            user =await _userService.Login(user);
            if (user != null)
            {
                return Ok(user);
            }
            return Unauthorized();
            

        }



        // POST: LoginController/Edit/5
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            try
            {
                User isSuccessRegist =await _userService.Register(user);
                if (isSuccessRegist != null)
                {
                    return Ok(isSuccessRegist);
                }
                return BadRequest();

            }
            catch(Exception ex)
            {
                throw ex;
            }


}

        [HttpPost]
        [Route("checkPassword")]
        public int checkPassword([FromBody]string password)
        {
            return _userService.checkPassword(password);
        }

        


        [HttpPut("{id}")]
        public async Task<ActionResult<User>> updateUser(int id, [FromBody] User newUser)
        {
            User updateUser=await _userService.updateUser(id,newUser);

            if (updateUser != null)
            {
                return Ok(newUser);
            };
            return BadRequest();
        }
    }
}
