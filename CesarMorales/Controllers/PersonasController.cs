using CesarMorales.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CesarMorales.Models;

namespace CesarMorales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaApplication _personaApplication;
        public PersonasController(IPersonaApplication personaApplication)
        {
            _personaApplication = personaApplication;
        }

        /// <summary>
        /// Get list of persons
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [ProducesResponseType(typeof(List<Persona>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Persona>>> GetPersonas()
        {
            try
            {
                var resp = await _personaApplication.GetPersonas();

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get a person by id
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref={T}<"/></returns>
        [HttpGet, Route("{personaId}")]
        [ProducesResponseType(typeof(Persona), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Persona>> GetPersona(int personaId)
        {
            try
            {
                var resp = await _personaApplication.GetPersona(personaId);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a person by Id
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref="bool<"/></returns>
        [HttpDelete, Route("{personaId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeletePersona(int personaId)
        {
            try
            {
                var resp = await _personaApplication.DeletePersona(personaId);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Insert a person
        /// </summary>
        /// <param name="payload">Parametro de tipo <see cref="Persona"/>.Modelo para agregar un articulo</param>
        /// <returns>Regresa objeto de tipo <see cref="{T}<"/></returns>
        [HttpPost, Route("")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> InsertPersona(Persona persona)
        {
            try
            {
                var resp = _personaApplication.InsertPersona(persona);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Update a person
        /// </summary>
        /// <param name="payload">Parametro de tipo <see cref="Persona"/>.Modelo para agregar un articulo</param>
        /// <returns>Regresa objeto de tipo <see cref="{T}<"/></returns>
        [HttpPut, Route("{personaId}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> UpdatePersona(Persona persona, int personaId)
        {
            try
            {
                var resp = _personaApplication.UpdatePersona(persona, personaId);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
