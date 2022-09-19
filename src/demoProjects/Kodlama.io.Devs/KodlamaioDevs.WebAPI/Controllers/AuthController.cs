using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Auths.Commands.RegisterCommand;
using KodlamaioDevs.Application.Features.Auths.Queries.LoginQuery;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            AccessToken result = await Mediator.Send(registerCommand);
            return Created("", result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
        {
            AccessToken result = await Mediator.Send(loginQuery);
            return Created("", result);
        }
    }
}
