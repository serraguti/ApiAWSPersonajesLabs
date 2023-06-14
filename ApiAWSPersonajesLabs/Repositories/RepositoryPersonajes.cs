using ApiAWSPersonajesLabs.Data;
using ApiAWSPersonajesLabs.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAWSPersonajesLabs.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await
                this.context.Personajes
                .FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        private int GetMaxIdPersonaje()
        {
            return this.context.Personajes.Max(z => z.IdPersonaje) + 1;
        }

        public async Task CreatePersonaje(string nombre
            , string imagen, string descripcion)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetMaxIdPersonaje();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.Descripcion = descripcion;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }
    }

}
