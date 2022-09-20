using AutoMapper;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using KodlamaioDevs.Application.Features.ProgrammingTechnologies.Dtos;
using KodlamaioDevs.Application.Features.ProgrammingTechnologies.Modes;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProgrammingLanguageCommand,ProgrammingTechnology>().ReverseMap();
            CreateMap<ProgrammingTechnology, CreatedProgrammingTechnologyDto>().ReverseMap();
            CreateMap<IPaginate<ProgrammingTechnology>, ProgrammingTechnologyListModel>().ReverseMap();
            CreateMap<ProgrammingTechnology, ProgrammingTechnologyListDto>().ForMember(c=>c.ProgrammingTechnologyName,opt=>opt.MapFrom(c=>c.ProgrammingLanguage.Name)).ReverseMap();
        }
    }
}
