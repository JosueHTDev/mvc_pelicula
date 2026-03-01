using DbModel.cineDb;
using DtoModel.Pelicula;
using Microsoft.EntityFrameworkCore;
using Mvc.Repository.GeneroPeliculaRepo.Contratos;
using Mvc.Repository.GeneroPeliculaRepo.Mapping;
using Mvc.Repository.PeliculaRepo.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Repository.GeneroPeliculaRepo.Implementacion
{
    public class GeneroPeliculaRepository : IGeneroPeliculaRepository
    {
        private readonly _cineContext _db;

        public GeneroPeliculaRepository(_cineContext db)
        {
            _db = db;
        }

        public Task<GeneroPeliculaDto> Create(GeneroPeliculaDto request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<GeneroPeliculaDto>> GetAll()
        {
            List<GeneroPeliculaDto> res = new List<GeneroPeliculaDto>();
            List<GeneroPelicula> data = await _db.GeneroPelicula.ToListAsync();
            res = GeneroPeliculaMapping.ToDtoList(data);
            return res;
        }

        public Task<GeneroPeliculaDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GeneroPeliculaDto> Update(GeneroPeliculaDto request)
        {
            throw new NotImplementedException();
        }
    }
}
