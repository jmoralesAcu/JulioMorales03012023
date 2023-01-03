using CesarMorales.Interfaces;
using System.Collections.Generic;

namespace CesarMorales.Models
{
    public class Infrastructure : IInfrastructure
    {
        private List<Persona> personas;
        public List<Persona> Personas
        {
            get
            {
                if (personas == null)
                    personas = new List<Persona>();
                return personas;
            }

            set { personas = value; }
        }
    }
}
