using DbModel.cineDb;
using DtoModel.Pelicula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Repository.PeliculaRepo.Mapping
{
    public static class PeliculaMapping
    {
        public static PeliculaDto ToDto(this Pelicula peli)
        {
            return new PeliculaDto
            {
                Id = peli.Id,
                IdGeneroPelicula = peli.IdGeneroPelicula,
                Titulo = peli.Titulo,
                Director = peli.Director,
                AnioEstreno = peli.AnioEstreno,
                DuracionMinutos = peli.DuracionMinutos,

                UserCreate = peli.UserCreate,
                UserUpdate = peli.UserUpdate,
                DateCreated = peli.DateCreated,
                DateUpdate = peli.DateUpdate
            };
        }

        public static Pelicula ToEntity(this PeliculaDto dto)
        {
            return new Pelicula
            {
                Id = dto.Id,
                IdGeneroPelicula = dto.IdGeneroPelicula,
                Titulo = dto.Titulo,
                Director = dto.Director,
                AnioEstreno = dto.AnioEstreno,
                DuracionMinutos = dto.DuracionMinutos,

                UserCreate = dto.UserCreate,
                UserUpdate = dto.UserUpdate,
                DateCreated = dto.DateCreated,
                DateUpdate = dto.DateUpdate
            };
        }

        public static List<PeliculaDto> ToDtoList(this List<Pelicula> peliculas)
        {
            return peliculas.Select(p => p.ToDto()).ToList();
        }
        public static List<Pelicula> ToEntityList(this List<PeliculaDto> peliculaDtos)
        {
            return peliculaDtos.Select(p => p.ToEntity()).ToList();
        }


    }
}
