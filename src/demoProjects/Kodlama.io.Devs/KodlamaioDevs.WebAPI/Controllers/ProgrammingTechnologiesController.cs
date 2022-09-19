using Core.Application.Requests;
using KodlamaioDevs.Application.Features.ProgrammingTechnologies.Modes;
using KodlamaioDevs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTechnologiesController : BaseController
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingTechnologyQuery query = new GetListProgrammingTechnologyQuery { PageRequest = pageRequest };
            ProgrammingTechnologyListModel programmingTechnologies = await Mediator.Send(query);
            return Ok(programmingTechnologies);
        }
    }
}
