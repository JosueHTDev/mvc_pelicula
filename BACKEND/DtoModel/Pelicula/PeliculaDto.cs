using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel.Pelicula
{
    public class PeliculaDto
    {
        public int Id { get; set; }
        public int IdGeneroPelicula { get; set; }
        public string? Titulo { get; set; }
        public string? Director { get; set; }
        public int? AnioEstreno { get; set; }
        public int? DuracionMinutos { get; set; }
        public int UserCreate { get; set; }
        public int? UserUpdate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
