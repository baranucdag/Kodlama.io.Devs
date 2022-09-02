using KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createSomeFeatureEntityCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createSomeFeatureEntityCommand);
            return Created("", result);
        }
    }
}
