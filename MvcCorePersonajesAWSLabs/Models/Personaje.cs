using Newtonsoft.Json;

namespace MvcCorePersonajesAWSLabs.Models
{
    public class Personaje
    {
        public int IdPersonaje { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }

    }
}
