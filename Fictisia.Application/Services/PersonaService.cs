using AutoMapper;
using Fictisia.Application.Dto;
using Fictisia.Application.Services.Interface;
using Fictisia.Infraestructure.Models;
using Fictisia.Infraestructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Persona> _personaRepository;
        private readonly IPersonaRepository _personasRepository;

        public PersonaService(IMapper mapper, IPersonaRepository personasRepository)
        {
            _mapper = mapper;
            _personasRepository = personasRepository;
            _personaRepository = personasRepository;
        }

        public async Task<List<PersonaDto?>> obtenerTodasLasPersonas()
        {
            try
            {
                var listaPersona = await _personaRepository.ObtenerTodos();

                return _mapper.Map<List<PersonaDto?>>(listaPersona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonaDto?> ObtenerPersonaPorId(int personaId)
        {
            try 
            {
                var persona = await _personasRepository.ObtenerPorIdAsync(personaId);

                var personaDto = _mapper.Map<PersonaDto?>(persona);

                return personaDto;
            }
            catch ( Exception ex)
            {
                throw ex;
            }

        }

        public async Task AgregarPersonaAsync(PersonaDto personaDto)
        {
            try
            {
                var New = new Persona{
                    Nombre = personaDto.Nombre,
                    Genero = personaDto.Genero,
                    Edad = personaDto.Edad,
                    Dni = personaDto.Dni,
                    Activo = new Estado
                    {
                        Activo = personaDto.Activo.Activo
                    },
                    Adicionales = new Adicionale
                    {
                        Maneja = personaDto.Adicionales.Maneja,
                        UsaLentes = personaDto.Adicionales.UsaLentes,
                        EsDiabetico = personaDto.Adicionales.EsDiabetico,
                        OtraEnfermedad = personaDto.Adicionales.OtraEnfermedad,
                        Comentarios = personaDto.Adicionales.Comentarios
                    }
                    
                };

                await _personaRepository.AddAsync(New);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task ActualizarPersonaAsync(PersonaDto personaDto)
        {
            try
            {
                var persona = _mapper.Map<Persona>(personaDto);

                await _personaRepository.UpdateAsync(persona);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task EliminarPersonaAsync(int personaId)
        {
            try
            {
                await _personaRepository.DeleteAsync(personaId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
