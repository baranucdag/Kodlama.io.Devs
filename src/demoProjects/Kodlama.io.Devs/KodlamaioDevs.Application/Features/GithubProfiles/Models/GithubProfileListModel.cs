using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.GithubProfiles.Dtos;

namespace KodlamaioDevs.Application.Features.GithubProfiles.Models
{
    public class GithubProfileListModel : BasePageableModel
    {
        public  IList<GithubProfileListDto> Items { get; set; }
    }
}
