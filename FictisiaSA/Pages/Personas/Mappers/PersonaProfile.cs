using AutoMapper;
using Fictisia.Application.Dto;
using FictisiaSA.Pages.Personas.Models;

namespace FictisiaSA.Pages.Personas.Mappers
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<PersonaDto, PersonaVM>().ReverseMap();

            // Mapeo de Estado
            CreateMap<EstadoDto, EstadoVM>().ReverseMap();

            // Mapeo de Adicionales
            CreateMap<AdicionalesDto, AdicionalesVM>().ReverseMap();
        }
    }
}
