using DtoModel.Pelicula;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc.Bussnies.GeneroPeliculaB;
using Mvc.Bussnies.Pelicula;

namespace Mvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroPeliculaController : ControllerBase
    {
        private readonly IGeneroPeliculaBussnies _generoBussnies;

        public GeneroPeliculaController(IGeneroPeliculaBussnies generoBussnies)
        {
            _generoBussnies = generoBussnies;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroPeliculaDto>>> Get()
        {
            return Ok(await _generoBussnies.GetAll());
        }
    }
}
