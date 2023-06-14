using ApiAWSPersonajesLabs.Models;
using ApiAWSPersonajesLabs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAWSPersonajesLabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePersonaje(Personaje personaje)
        {
            await this.repo.CreatePersonaje(personaje.Nombre
                , personaje.Imagen, personaje.Descripcion);
            return Ok();
        }
    }
}
