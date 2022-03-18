using ApiPersonajesSeriesJLR.Data;
using ApiPersonajesSeriesJLR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonajesSeriesJLR.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;
        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }
        private int GetMaxIdSeries()
        {
            if (this.context.Series.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Series.Count() + 1;
            }
        }
        private int GetMaxIdPersonajes()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Personajes.Count() + 1;
            }
        }
        //METODOS GET
        public List<Serie> GetSeries()
        {
            return this.context.Series.ToList();
        }
        public Serie FindSerie(int idserie)
        {
            return this.context.Series.FirstOrDefault(x => x.IdSerie == idserie);
        }
        public List<Personaje> FindPersonajeSerie(int idserie)
        {
            var consulta = from datos in this.context.Personajes
                           where datos.IdSerie == idserie
                           select datos;
            return consulta.ToList();
        }

        public List<Personaje> GetPersonajes()
        {
            return this.context.Personajes.ToList();
        }
        public Personaje FindPersonaje(int idpersonaje)
        {
            return this.context.Personajes.FirstOrDefault(x => x.IdPersonaje == idpersonaje);
        }
        //METODOS POST
        public void InsertarSerie( string nombre, string imagen, double puntuacion, int año)
        {
            Serie serie = new Serie();
            serie.IdSerie = this.GetMaxIdSeries();
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Puntuacion = puntuacion;
            serie.Año = año;
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }

        public void InsertarPersonaje(string nombre, string imagen, int idserie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetMaxIdPersonajes();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.Personajes.Add(personaje);
            this.context.SaveChanges();
        }

        //METODOS PUT
        public void UpdateSeries(int idserie, string nombre, string imagen, double puntuacion, int año)
        {
            Serie serie = this.FindSerie(idserie);
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Puntuacion = puntuacion;
            serie.Año = año;
            this.context.SaveChanges();
        }
        public void UpdatePersonajes(int idpersonaje, string nombre, string imagen, int idserie)
        {
            Personaje personaje = this.FindPersonaje(idpersonaje);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdPersonaje = idserie;
            this.context.SaveChanges();
        }
        public void UpdatePersonajeSerie(int idpersonaje, int idserie)
        {
            Personaje personaje = this.FindPersonaje(idpersonaje);
            personaje.IdSerie = idserie;
            this.context.SaveChanges();
        }
        //METODOS DELETE
        public void DeleteSerie(int idserie)
        {
            Serie serie = this.FindSerie(idserie);
            this.context.Remove(serie);
            this.context.SaveChanges();
        }
        public void DeletePersonaje(int idpersonaje)
        {
            Personaje personaje = this.FindPersonaje(idpersonaje);
            this.context.Remove(personaje);
            this.context.SaveChanges();
        }

    }
}
