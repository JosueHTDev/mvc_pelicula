using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbModel.cineDb;

[Table("pelicula")]
[Index("IdGeneroPelicula", Name = "fk_pelicula_genero")]
public partial class Pelicula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_genero_pelicula")]
    public int IdGeneroPelicula { get; set; }

    [Column("titulo")]
    [StringLength(100)]
    public string? Titulo { get; set; }

    [Column("director")]
    [StringLength(100)]
    public string? Director { get; set; }

    [Column("anio_estreno")]
    public int? AnioEstreno { get; set; }

    [Column("duracion_minutos")]
    public int? DuracionMinutos { get; set; }

    [Column("user_create")]
    public int UserCreate { get; set; }

    [Column("user_update")]
    public int? UserUpdate { get; set; }

    [Column("date_created", TypeName = "timestamp")]
    public DateTime? DateCreated { get; set; }

    [Column("date_update", TypeName = "timestamp")]
    public DateTime? DateUpdate { get; set; }

    [ForeignKey("IdGeneroPelicula")]
    [InverseProperty("Pelicula")]
    public virtual GeneroPelicula IdGeneroPeliculaNavigation { get; set; } = null!;
}
