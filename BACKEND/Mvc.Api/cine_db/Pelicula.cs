using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Api.cine_db;

[Table("pelicula")]
[Index("IdGeneroPelicula", Name = "fk_pelicula_genero")]
public partial class Pelicula
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("id_genero_pelicula", TypeName = "int(11)")]
    public int IdGeneroPelicula { get; set; }

    [Column("titulo")]
    [StringLength(150)]
    public string Titulo { get; set; } = null!;

    [Column("director")]
    [StringLength(100)]
    public string? Director { get; set; }

    [Column("anio_estreno", TypeName = "year(4)")]
    public short? AnioEstreno { get; set; }

    [Column("duracion_minutos", TypeName = "int(11)")]
    public int? DuracionMinutos { get; set; }

    [Column("user_create", TypeName = "int(11)")]
    public int UserCreate { get; set; }

    [Column("user_update", TypeName = "int(11)")]
    public int? UserUpdate { get; set; }

    [Column("date_created", TypeName = "timestamp")]
    public DateTime DateCreated { get; set; }

    [Column("date_update", TypeName = "timestamp")]
    public DateTime? DateUpdate { get; set; }

    [ForeignKey("IdGeneroPelicula")]
    [InverseProperty("Pelicula")]
    public virtual GeneroPelicula IdGeneroPeliculaNavigation { get; set; } = null!;
}
