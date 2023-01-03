using CesarMorales.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CesarMorales.Interfaces
{
    public interface IPersonaApplication
    {
        public Task<List<Persona>> GetPersonas();
        public Task<Persona> GetPersona(int personaId);
        public Task<int> InsertPersona(Persona persona);
        public Task<Persona> UpdatePersona(Persona persona, int personaId);
        public Task<bool> DeletePersona(int personaId);
    }
}
