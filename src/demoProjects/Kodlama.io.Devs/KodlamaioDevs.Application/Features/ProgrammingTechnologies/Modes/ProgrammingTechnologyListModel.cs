using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.ProgrammingTechnologies.Dtos;

namespace KodlamaioDevs.Application.Features.ProgrammingTechnologies.Modes
{
    public class ProgrammingTechnologyListModel : BasePageableModel
    {
        public IList<ProgrammingTechnologyListDto> Items { get; set; }
    }
}
