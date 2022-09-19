using AutoMapper;
using Core.Application.Requests;
using KodlamaioDevs.Application.Features.GithubProfiles.Models;

namespace KodlamaioDevs.Application.Features.GithubProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
           CreateMap<GithubProfileListModel, PageRequest>().ReverseMap();
        }
    }
}
