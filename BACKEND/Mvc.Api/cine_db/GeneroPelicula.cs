using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Api.cine_db;

[Table("genero_pelicula")]
public partial class GeneroPelicula
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("nombre_genero")]
    [StringLength(50)]
    public string NombreGenero { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(150)]
    public string? Descripcion { get; set; }

    [Column("user_create", TypeName = "int(11)")]
    public int UserCreate { get; set; }

    [Column("user_update", TypeName = "int(11)")]
    public int? UserUpdate { get; set; }

    [Column("date_created", TypeName = "timestamp")]
    public DateTime DateCreated { get; set; }

    [Column("date_update", TypeName = "timestamp")]
    public DateTime? DateUpdate { get; set; }

    [InverseProperty("IdGeneroPeliculaNavigation")]
    public virtual ICollection<Pelicula> Pelicula { get; set; } = new List<Pelicula>();
}
