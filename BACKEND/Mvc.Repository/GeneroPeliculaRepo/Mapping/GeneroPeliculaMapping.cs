using DbModel.cineDb;
using DtoModel.Pelicula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Repository.GeneroPeliculaRepo.Mapping
{
    public static class GeneroPeliculaMapping
    {
        public static GeneroPeliculaDto ToDto(this GeneroPelicula peli)
        {
            return new GeneroPeliculaDto
            {
                Id = peli.Id,
                NombreGenero = peli.NombreGenero,
                Descripcion = peli.Descripcion,
                UserCreate = peli.UserCreate,
                UserUpdate = peli.UserUpdate,
                DateCreated = peli.DateCreated,
                DateUpdate = peli.DateUpdate
            };
        }

        public static GeneroPelicula ToEntity(this GeneroPeliculaDto request)
        {
            return new GeneroPelicula
            {
                Id = request.Id,
                NombreGenero = request.NombreGenero,
                Descripcion = request.Descripcion,
                UserCreate = request.UserCreate,
                UserUpdate = request.UserUpdate,
                DateCreated = request.DateCreated,
                DateUpdate = request.DateUpdate
            };
        }

        public static List<GeneroPeliculaDto> ToDtoList(this List<GeneroPelicula> peliculas)
        {
            return peliculas.Select(p => p.ToDto()).ToList();
        }
        public static List<GeneroPelicula> ToEntityList(this List<GeneroPeliculaDto> GeneroPeliculaDtos)
        {
            return GeneroPeliculaDtos.Select(p => p.ToEntity()).ToList();
        }
    }
}
