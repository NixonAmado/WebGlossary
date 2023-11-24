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
        // CreateMap<Pet, PetStatDto>()
        // .ForMember(e => e.Breed, op => op.MapFrom(e => e.Breed.Name))
        // .ForMember(e => e.Species, op => op.MapFrom(e => e.Species.Name))
        CreateMap<PVerbalTenseDescriptionDto, Phaseverbaltense>().ReverseMap();
        CreateMap<PStructureDescriptionDto, Phasestructure>().ReverseMap();
        CreateMap<PTypeDescriptionDto, Phasetype>().ReverseMap();
        CreateMap<G_PhaseDto, Phase>().ReverseMap();

    }
}