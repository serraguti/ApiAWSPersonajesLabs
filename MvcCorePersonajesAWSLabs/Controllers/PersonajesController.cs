using Microsoft.AspNetCore.Mvc;
using MvcCorePersonajesAWSLabs.Models;
using MvcCorePersonajesAWSLabs.Services;

namespace MvcCorePersonajesAWSLabs.Controllers
{
    public class PersonajesController : Controller
    {
        private ServiceApiPersonajes service;
        private ServiceStorageS3 serviceStorage;

        public PersonajesController(ServiceApiPersonajes service
            , ServiceStorageS3 serviceStorage)
        {
            this.service = service;
            this.serviceStorage = serviceStorage;
        }
        public async Task<IActionResult> Index()
        {
            List<Personaje> personajes = await this.service.GetPersonajesAsync();
            return View(personajes);
        }

        public async Task<IActionResult> Details(int id)
        {
            Personaje personaje = await this.service.FindPersonajeAsync(id);
            return View(personaje);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> 
            Create(Personaje personaje, IFormFile file)
        {
            personaje.Imagen = file.FileName;
            using (Stream stream = file.OpenReadStream())
            {
                await this.serviceStorage.UploadFileAsync(personaje.Imagen, stream);
            }

            await this.service.CreatePersonajeAsync(personaje);
            return RedirectToAction("Index");
        }


    }
}
