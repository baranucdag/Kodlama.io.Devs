using Core.Application.Requests;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Models;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createSomeFeatureEntityCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createSomeFeatureEntityCommand);
            return Created("", result);
        }


        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(programmingLanguageGetByIdDto);
        }
    }
}
