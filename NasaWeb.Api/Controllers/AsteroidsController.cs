using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NasaWeb.Api.Interfaces;
using NasaWeb.Api.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NasaWeb.Api.Controllers
{
    //    [SwaggerTag("Asteroids", Description = "Web API para obtener el Top 3 de asteroides más grandes con potencial riesgo de impacto.")]
    [Route("[controller]")]
    [ApiController]
    public class AsteroidsController : Controller
    {
        private readonly IAsteroidRepository _asteroidRepository;

        public AsteroidsController(IAsteroidRepository asteroidRepository)
        {
            _asteroidRepository = asteroidRepository;
        }

        /// <summary>
        ///  Top 3 de asteroides más grandes con potencial riesgo de impacto
        /// </summary>
        /// <param name="planeta">Nombre del planeta a buscar</param>
        /// <returns></returns>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [HttpGet("{planeta}") ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Asteroids>>> GetAsteroids(string planeta)
        {
            if (planeta != null)
            {
                try
                {
                    var asteroids = await _asteroidRepository.GetAsteroids(planeta);

                    if (asteroids.Count() < 1)
                    {
                        return NotFound();
                    }

                    return Ok(asteroids);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
