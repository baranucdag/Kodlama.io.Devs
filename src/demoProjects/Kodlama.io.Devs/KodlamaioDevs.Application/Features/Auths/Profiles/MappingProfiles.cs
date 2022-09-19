using AutoMapper;
using Core.Security.Entities;
using KodlamaioDevs.Application.Features.Auths.Commands.RegisterCommand;

namespace KodlamaioDevs.Application.Features.Auths.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<User, RegisterCommand>().ReverseMap();
        }
    }
}
