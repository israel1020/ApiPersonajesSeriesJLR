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
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repository;
        public SeriesController(RepositorySeries repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<List<Serie>> GetSeries()
        {
            return this.repository.GetSeries();
        }
        [HttpPost]
        public ActionResult InsertarSerie(Serie serie)
        {
            this.repository.InsertarSerie(serie.Nombre, serie.Imagen, serie.Puntuacion, serie.Año);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateSerie(Serie serie)
        {
            this.repository.UpdateSeries(serie.IdSerie, serie.Nombre, serie.Imagen, serie.Puntuacion, serie.Año);
            return Ok();
        }
        [HttpGet]
        [Route("{idserie}")]
        public ActionResult<Serie> FindSerie(int idserie)
        {
            return this.repository.FindSerie(idserie);
        }
        [HttpDelete]
        [Route("{idserie}")]
        public ActionResult<Serie> DeleteSerie(int idserie)
        {
            this.repository.DeleteSerie(idserie);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{idserie}")]
        public ActionResult<List<Personaje>> PersonajesSerie(int idserie)
        {
            return this.repository.FindPersonajeSerie(idserie);
        }
    }
}
