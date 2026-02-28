using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbModel.cineDb;
using Microsoft.EntityFrameworkCore;

namespace DbModel.cineDb;

[Table("genero_pelicula")]
public partial class GeneroPelicula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre_genero")]
    [StringLength(20)]
    public string NombreGenero { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(50)]
    public string Descripcion { get; set; } = null!;

    [Column("user_create")]
    public int UserCreate { get; set; }

    [Column("user_update")]
    public int? UserUpdate { get; set; }

    [Column("date_created", TypeName = "timestamp")]
    public DateTime? DateCreated { get; set; }

    [Column("date_update", TypeName = "timestamp")]
    public DateTime? DateUpdate { get; set; }

    [InverseProperty("IdGeneroPeliculaNavigation")]
    public virtual ICollection<Pelicula> Pelicula { get; set; } = new List<Pelicula>();
}
