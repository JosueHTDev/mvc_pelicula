using DtoModel.Pelicula;
using Mvc.Repository.PeliculaRepo.Contratos;
using Mvc.Repository.PeliculaRepo.Implementacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mvc.Bussnies.Pelicula
{
    public class PeliculaBussnies : IPeliculaBussnies
    {
        private readonly IPeliculaRepository _peliculaRepository;

        public PeliculaBussnies(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }

        public async Task<PeliculaDto> Create(PeliculaDto request)
        {
            PeliculaDto result = await _peliculaRepository.Create(request);
            return result;
        }

        public async Task<List<PeliculaDto>> GetAll()
        {
            List<PeliculaDto> lista = await _peliculaRepository.GetAll();
            return lista;
        }

        public async Task<PeliculaDto?> GetById(int id)
        {
            PeliculaDto peli = await _peliculaRepository.GetById(id);

            return peli;

        }

        public async Task<PeliculaDto?> Update(PeliculaDto request)
        {
            PeliculaDto? peliculaDb = await _peliculaRepository.GetById(request.Id);

            if (peliculaDb == null)
            {
                throw new Exception("Persona a actualizar no existe");
            }

            
            PeliculaDto result = await _peliculaRepository.Update(request);

            return result;

        }

        public async Task Delete(int id)
        {
            await _peliculaRepository.Delete(id);
        }
    }
}
