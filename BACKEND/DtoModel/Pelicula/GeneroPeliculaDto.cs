using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel.Pelicula
{
    public class GeneroPeliculaDto
    {
        public int Id { get; set; }
        public string NombreGenero { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int UserCreate { get; set; }
        public int? UserUpdate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }

    }
}
