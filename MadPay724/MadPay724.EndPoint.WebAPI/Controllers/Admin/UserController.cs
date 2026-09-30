using MadPay724.Common.Messages;
using MadPay724.Data.DTOs;
using MadPay724.Data.Models;
using MadPay724.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.EndPoint.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("site/admin/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> Get()
        {
            var model = await _userService.GetAll();
            return Ok(model);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO model)
        {
            var user = _userService.Login(model);
            if (user is null)
                return Unauthorized(new Message()
                {
                    Status = false,
                    Title = "خطا",
                    Description = "کاربری با این مشخصات یافت نشد"
                });

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("appSettings:token").Value));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = model.IsRemember ? DateTime.Now.AddDays(1) : DateTime.Now.AddHours(2),
                SigningCredentials = credential
            };

            var tokenHendler = new JwtSecurityTokenHandler();
            var token = tokenHendler.CreateToken(tokenDescription);

            return Ok(new { token = tokenHendler.WriteToken(token) });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(User model)
        {
            var s = await _userService.Register(model, "123");

            //var user = new User
            //{
            //    Address = "Tehran",
            //    City = "Tehran",
            //    DateOfBirth = "1365/09/29",
            //    FullName = "AbolfazlPirhadi",
            //    IsActive = true,
            //    UserName = "Abed",
            //    Status = true,
            //    PasswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, },
            //    PasswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, },
            //};

            ////await _dbContext.UserRepository.Add(user);
            ////await _dbContext.SaveAsync();

            //await _userService.Register(user,"123");
            return StatusCode(200);
        }


        [Authorize]
        [HttpGet("getValue")]
        public async Task<IActionResult> GetValue()
        {
            return Ok(new Message()
            {
                Status = true,
                Title = "OK",
                Description = ""
            });
        }

        [HttpGet("getValues")]
        public async Task<IActionResult> GetValues()
        {
            return Ok(new Message()
            {
                Status = true,
                Title = "OK",
                Description = ""
            });
        }
    }
}
