using CesarMorales.Models;
using System.Collections.Generic;

namespace CesarMorales.Interfaces
{
    public interface IInfrastructure
    {
        public List<Persona> Personas { get; set; }
    }
}
