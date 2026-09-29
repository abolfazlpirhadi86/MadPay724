using MadPay724.Data.DataBaseContext;
using MadPay724.Data.DTOs;
using MadPay724.Data.Models;
using MadPay724.Repository.Infrastructure;
using MadPay724.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MadPay724.EndPoint.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("site/admin/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> Get()
        {
            var model = await _userService.GetAll();
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Regsiter(RegisterUserDTO model) 
        {
            //var s = await _userService.Register(model,"123");

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
    }
}
