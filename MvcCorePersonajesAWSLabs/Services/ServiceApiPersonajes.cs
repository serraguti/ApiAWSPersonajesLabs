using MvcCorePersonajesAWSLabs.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcCorePersonajesAWSLabs.Services
{
    public class ServiceApiPersonajes
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceApiPersonajes(KeysModel model)
        {
            this.UrlApi = model.ApiPersonajes;
            this.Header =
new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                string urlRequest = this.UrlApi + request;
                HttpResponseMessage response =
                    await client.GetAsync(urlRequest);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            string request = "api/personajes";
            List<Personaje> personajes = await this.CallApiAsync<List<Personaje>>(request);
            return personajes;
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            string request = "api/personajes/" + id;
            Personaje personaje = await this.CallApiAsync<Personaje>(request);
            return personaje;
        }

        public async Task CreatePersonajeAsync(Personaje personaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/personajes";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                string jsonPersonaje = JsonConvert.SerializeObject(personaje);
                StringContent content =
                    new StringContent(jsonPersonaje, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(this.UrlApi + request, content);
            }
        }

    }
}
