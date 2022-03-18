using ApiPersonajesSeriesJLR.Models;
using ApiPersonajesSeriesJLR.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonajesSeriesJLR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeries repository;
        public PersonajesController(RepositorySeries repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<List<Personaje>> GetPersonajes()
        {
            return this.repository.GetPersonajes();
        }
        [HttpPost]
        public ActionResult InsertarPersonaje(Personaje personaje)
        {
            this.repository.InsertarPersonaje(personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdatePersonaje(Personaje personaje)
        {
            this.repository.UpdatePersonajes(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.IdPersonaje);
            return Ok();
        }
        [HttpGet]
        [Route("{idpersonaje}")]
        public ActionResult<Personaje> FindPersonaje(int idpersonaje)
        {
            return this.repository.FindPersonaje(idpersonaje);
        }
        [HttpDelete]
        [Route("{idpersonaje}")]
        public ActionResult<Personaje> DeletePersonaje(int idpersonaje)
        {
            this.repository.DeletePersonaje(idpersonaje);
            return Ok();
        }
        [HttpPut]
        [Route("{idpersonaje}/{idserie}")]
        public ActionResult<Personaje> UpdatePersonajeSerie(int idpersonaje, int idserie)
        {
            this.repository.UpdatePersonajeSerie(idpersonaje, idserie);
            return Ok();
        }
    }
}
