using DtoModel.Pelicula;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc.Bussnies.Pelicula;

namespace Mvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PeliculaController : ControllerBase
    {

        private readonly IPeliculaBussnies _peliculaBussnies;

        public PeliculaController(IPeliculaBussnies peliculaBussnies)
        {
            _peliculaBussnies = peliculaBussnies;
        }


        [HttpGet]
        public async Task<ActionResult<List<PeliculaDto>>> GetAll()
        {
            List<PeliculaDto> list = await _peliculaBussnies.GetAll();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PeliculaDto>> GetById(int id)
        {
            PeliculaDto? pelicula = await _peliculaBussnies.GetById(id);

            if (pelicula == null)
            {
                return NotFound(new { message = "Pelicula no encontrada" });
            }

            return Ok(pelicula);
        }

        [HttpPost]
        public async Task<ActionResult<PeliculaDto>> Create([FromBody] PeliculaDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PeliculaDto pelicula = await _peliculaBussnies.Create(request);

            return CreatedAtAction(nameof(GetById), new { id = pelicula.Id }, pelicula);
        }

        [HttpPut]
        public async Task<ActionResult<PeliculaDto>> Update([FromBody] PeliculaDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PeliculaDto? pelicula = await _peliculaBussnies.Update(request);

            if (pelicula == null)
            {
                return NotFound(new { message = "Pelicula no encontrada" });
            }

            return Ok(pelicula);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            PeliculaDto? pelicula = await _peliculaBussnies.GetById(id);

            if (pelicula == null)
            {
                return NotFound(new { message = "Pelicula no encontrada" });
            }

            await _peliculaBussnies.Delete(id);

            return NoContent();
        }


    }
}
