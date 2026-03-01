using DtoModel.Pelicula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Bussnies.GeneroPeliculaB
{
    public interface IGeneroPeliculaBussnies
    {
        Task<List<GeneroPeliculaDto>> GetAll();
    }
}
