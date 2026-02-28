using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Mvc.Api.cine_db;

public partial class _cineContext : DbContext
{
    public _cineContext()
    {
    }

    public _cineContext(DbContextOptions<_cineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GeneroPelicula> GeneroPelicula { get; set; }

    public virtual DbSet<Pelicula> Pelicula { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Si no usas contraseña en local, deja Pwd=; pero mejor mover a appsettings/user secrets.
            var connectionString = "server=localhost;port=3306;database=cine_db;uid=root;pwd=;SslMode=None;AllowPublicKeyRetrieval=True";
            optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<GeneroPelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.DateCreated).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.DateUpdate).ValueGeneratedOnAddOrUpdate();
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.DateCreated).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.DateUpdate).ValueGeneratedOnAddOrUpdate();

            entity.HasOne(d => d.IdGeneroPeliculaNavigation).WithMany(p => p.Pelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pelicula_genero");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
