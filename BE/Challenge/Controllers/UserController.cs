using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PRJ.API.JWT;
using PRJ.Service.Services.User.DTOs;
using PRJ.Service.Services.UserServices;
using PRJ.Service.Services.UserServices.DTOs;
using PRJ.Utility.DTOs;
using PRJ.Utility.OutputData;
using System;
using System.Net;

namespace ShoppingPortal.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserInputDTO request)
        {
            if (!await _userService.IsEmailExist(request.Email))
                return Ok(new OutputDTO<UserOutputDTO>()
                {
                    Data = null,
                    HttpStatusCode = (int)HttpStatusCode.Conflict,
                    Message = "email is already exist",
                    Succeeded = false
                });

            var result = await _userService.Register(request);
            if (result.Succeeded)
            {
                result.Data.JwtToken = JWT.GenerateJwtToken(new SessionDTO
                {
                    UserId = result.Data.UserId,
                    Email = result.Data.Email,
                    RoleId = result.Data.RoleId,
                    Name = $"{result.Data.FirstName} {result.Data.LastName}",
                }, _configuration);
            }
            return Ok(result);
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var result = await _userService.Login(dto);
            if (result.Succeeded && !(result.Data is null))
            {
                result.Data.JwtToken = JWT.GenerateJwtToken(new SessionDTO
                {
                    UserId = result.Data.UserId,
                    Email = result.Data.Email,
                    RoleId = result.Data.RoleId,
                    Name = $"{result.Data.FirstName} {result.Data.LastName}",
                }, _configuration);
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("weather")]
        [AllowAnonymous]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
