using DtoModel.Pelicula;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mvc.Bussnies.Pelicula
{
    public interface IPeliculaBussnies
    {
        Task<List<PeliculaDto>> GetAll();
        Task<PeliculaDto?> GetById(int id);
        Task<PeliculaDto> Create(PeliculaDto request);
        Task<PeliculaDto?> Update(PeliculaDto request);
        Task Delete(int id);
    }
}