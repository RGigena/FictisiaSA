using AutoMapper;
using Fictisia.Application.Dto;
using Fictisia.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Application.Mappers
{
    /// <summary>
    /// Perfil AutoMapper que define mapeos entre las entidades del dominio y los DTOs asociados a personas.
    /// </summary>
    /// 

    public class PersonaProfile : Profile
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PersonaProfile"/> y configura los mapeos entre las entidades del dominio y los DTOs asociados a personas.
        /// </summary>
        /// 

        public PersonaProfile() 
        {
            CreateMap<Persona, PersonaDto>().ReverseMap();

            CreateMap<Estado, EstadoDto>().ReverseMap();

            CreateMap<Adicionale, AdicionalesDto>().ReverseMap();
        }
    }
}
