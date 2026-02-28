using DbModel.cineDb;
using DtoModel.Pelicula;
using Microsoft.EntityFrameworkCore;
using Mvc.Repository.PeliculaRepo.Contratos;
using Mvc.Repository.PeliculaRepo.Mapping;

namespace Mvc.Repository.PeliculaRepo.Implementacion
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly _cineContext _db;

        public PeliculaRepository(_cineContext db)
        {
            _db = db;
        }

        public async Task<PeliculaDto> Create(PeliculaDto request)
        {
            request.IdGeneroPelicula = 1;
            Pelicula peli = PeliculaMapping.ToEntity(request);
            await _db.Pelicula.AddAsync(peli);
            await _db.SaveChangesAsync();

            request = PeliculaMapping.ToDto(peli);
            return request;
        }

        public async Task Delete(int id)
        {
            await _db.Pelicula.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<PeliculaDto>> GetAll()
        {
            List<PeliculaDto> res = new List<PeliculaDto>();
            List<Pelicula> data = await _db.Pelicula.ToListAsync();
            res = PeliculaMapping.ToDtoList(data);
            return res;
        }

        public async Task<PeliculaDto?> GetById(int id)
        {
            Pelicula? pelicula = await _db.Pelicula.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (pelicula == null) { return null; }
            PeliculaDto res = PeliculaMapping.ToDto(pelicula);
            return res;
        }

        public async Task<PeliculaDto> Update(PeliculaDto request)
        {
            var peli = await _db.Pelicula.FindAsync(request.Id);
            try
            {
                // Obtener la entidad existente desde la base de datos

                if (peli == null)
                {
                    throw new Exception("Pelicula no encontrada");
                }

                // Actualizar las propiedades
                peli.IdGeneroPelicula = request.IdGeneroPelicula;
                peli.Titulo = request.Titulo;
                peli.Director = request.Director;
                peli.AnioEstreno = request.AnioEstreno;
                peli.DuracionMinutos = request.DuracionMinutos;
                peli.UserUpdate = request.UserUpdate;
                peli.DateUpdate = request.DateUpdate;

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return PeliculaMapping.ToDto(peli);
        }
    }
}


// programación en segundo plano
// programación en hilos