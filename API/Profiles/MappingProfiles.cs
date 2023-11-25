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
        CreateMap<G_PVerbalTenseDto, Phaseverbaltense>().ReverseMap();

        CreateMap<Verbaltense, G_VerbalTenseDto>().ReverseMap();

        CreateMap<G_PStructureDto, Phasestructure>().ReverseMap();

        CreateMap<G_PTypeDto, Phasetype>().ReverseMap();

        CreateMap<G_PhaseDto, Phase>().ReverseMap();

        CreateMap<Wordtype, G_WTypeDto>().ReverseMap();

        CreateMap<Word, G_WordDto>()
        .ForMember(w => w.Word, op => op.MapFrom(e => e.WordText))
        .ForMember(w => w.Plural, op => op.MapFrom(e => e.Plural == 1 ? "True" : "False"))
        .ForMember(w => w.VerbalTense, op => op.MapFrom(e => e.VerbalTense.Description))
        .ForMember(w => w.WordType, op => op.MapFrom(e => e.WordType.Description))
        .ReverseMap();

        CreateMap<Phase, G_PhaseDto>()
            .ForMember(e => e.Phase, op => op.MapFrom(e => e.Phase1))
            .ForMember(e => e.Structure, op => op.MapFrom(e => e.PhaseStructure.Description))
            .ForMember(e => e.Type, op => op.MapFrom(e => e.PhaseType.Description))
            .ForMember(e => e.VerbalTense, op => op.MapFrom(e => e.PhaseVerbalTense.Description))
            .ReverseMap();
        

    }
}