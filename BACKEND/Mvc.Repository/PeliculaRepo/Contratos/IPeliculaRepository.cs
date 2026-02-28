using DtoModel.Pelicula;
using Mvc.Repository.General.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Repository.PeliculaRepo.Contratos
{

    /*RECUERDEN QUE LAS INTERFACES, SOLO SIRVEN PARA DECLARAR LOS METODOS A IMPLEMENTAR*/


    //IDisposable => garbace collector, para liberar recursos no administrados, como conexiones a bases de datos, archivos, etc.

    //herendando ICrudRepository<T>
    public interface IPeliculaRepository: ICrudRepository<PeliculaDto>, IDisposable
    {


    }
}