using DtoModel.Pelicula;
using Mvc.Repository.GeneroPeliculaRepo.Contratos;
using Mvc.Repository.PeliculaRepo.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Bussnies.GeneroPeliculaB
{
    public class GeneroPeliculaBussnies : IGeneroPeliculaBussnies
    {
        private readonly IGeneroPeliculaRepository _generoRepository;

        public GeneroPeliculaBussnies(IGeneroPeliculaRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        public async Task<List<GeneroPeliculaDto>> GetAll()
        {
            List < GeneroPeliculaDto > lista = await _generoRepository.GetAll();
            
            return lista;
        }
    }
}
