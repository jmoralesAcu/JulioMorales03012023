using CesarMorales.Interfaces;
using CesarMorales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CesarMorales.ApplicationLayer
{
    public class PersonaApplication : IPersonaApplication
    {
        private readonly IInfrastructure _infrastructure;
        public PersonaApplication(IInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }
        public async Task<bool> DeletePersona(int personaId)
        {
            try
            {
                var newList = _infrastructure.Personas.Where(x => x.Id != personaId);

                _infrastructure.Personas = newList.ToList();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Issue to delete personas, error: {ex.Message}");
            }
        }

        public async Task<Persona> GetPersona(int personaId)
        {
            try
            {
                return Task.Run(() => _infrastructure.Personas.FirstOrDefault(x => x.Id == personaId)).Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Issue to get persona, error: {ex.Message}");
            }
        }

        public async Task<List<Persona>> GetPersonas()
        {
            try
            {
                return Task.Run(() => _infrastructure.Personas).Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Issue to get personas, error: {ex.Message}");
            }
        }

        public async Task<int> InsertPersona(Persona persona)
        {
            try
            {
                var nextid = _infrastructure.Personas.Count() == 0 ? 1 : _infrastructure.Personas.Max(x => x.Id) + 1;
                persona.Id = nextid;

                _infrastructure.Personas.Add(persona);

                return persona.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Issue to insert personas, error: {ex.Message}");
            }
        }

        public async Task<Persona> UpdatePersona(Persona persona, int personaId)
        {
            try
            {
                var newList = _infrastructure.Personas.Where(x => x.Id != personaId);
                _infrastructure.Personas = newList.ToList();
                _infrastructure.Personas.Add(persona);

                return persona;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Issue to update personas, error: {ex.Message}");
            }
        }
    }
}
