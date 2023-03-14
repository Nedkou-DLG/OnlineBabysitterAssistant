
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.User;
using OnlineBabysitterAssistant.Web.Appplication.Configurations.Helpers;
using OnlineBabysitterAssistant.Web.Appplication.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Web.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthorizationController : ControllerBase
    {
        
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AuthorizationController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost("login")]
        public IActionResult Authenticate(LoginUserModel model)
        {
            var response = _userService.Authenticate(model);

            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserModel model)
        {
            var result = await _userService.RegisterUser(model);
                
            return Ok(result);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            // only admins can access other user records
            var currentUser = (UserRecord)HttpContext.Items["User"];
            if (id != currentUser?.Id && currentUser?.Type != UserType.PARENT)
                return Unauthorized(new { message = "Unauthorized" });

            var user = _userService.GetById(id);
            return Ok(user);
        }
        
        [HttpGet("info/{id}")]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserInfo(int id)
        {
            try
            {
                var response = await _userService.GetUserInfo(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUserInfo(UpdateUserInfo profile)
        {
            try
            {
                var response = await _userService.UpdateUser(profile.Id, profile);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
