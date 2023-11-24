using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //CreateMap<Role, RoleDto>().ReverseMap();
        //CreateMap<PersonType, TypePDto>().ReverseMap();
        // CreateMap<Pet, FullPetDto>().ReverseMap();
         CreateMap<Phase, G_PhaseDto>()
            .ForMember(e => e.Phase, op => op.MapFrom(e => e.Phase1))
            .ForMember(e => e.Structure, op => op.MapFrom(e => e.PhaseStructure))
            .ForMember(e => e.Type, op => op.MapFrom(e => e.PhaseType))
            .ForMember(e => e.VerbalTense, op => op.MapFrom(e => e.PhaseVerbalTense))
            .ReverseMap();

        CreateMap<PVerbalTenseDescriptionDto, Phaseverbaltense>().ReverseMap();
        CreateMap<PStructureDescriptionDto, Phasestructure>().ReverseMap();
        CreateMap<PTypeDescriptionDto, Phasetype>().ReverseMap();
        CreateMap<G_PhaseDto, Phase>().ReverseMap();

    }
}