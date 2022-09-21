using Core.Application.Requests;
using Core.Persistence.Dynamic;
using KodlamaioDevs.Application.Features.ProgrammingTechnologies.Modes;
using KodlamaioDevs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology;
using KodlamaioDevs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingTechnologyQuery query = new GetListProgrammingTechnologyQuery { PageRequest = pageRequest };
            ProgrammingTechnologyListModel programmingTechnologies = await Mediator.Send(query);
            return Ok(programmingTechnologies);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListProgrammingTechnologyByDynamicQuery getListByDynamicProgrammingTechnologyQuery = new GetListProgrammingTechnologyByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            ProgrammingTechnologyListModel result = await Mediator.Send(getListByDynamicProgrammingTechnologyQuery);
            return Ok(result);

        }
    }
}
