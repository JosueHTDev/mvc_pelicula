using DtoModel.Pelicula;
using Mvc.Repository.General.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Repository.PeliculaRepo.Contratos
{
    public interface IPeliculaRepository: ICrudRepository<PeliculaDto>, IDisposable
    {


    }
}