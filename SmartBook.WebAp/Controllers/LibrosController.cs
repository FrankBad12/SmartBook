using SmartBook.Application.Services;
using SmartBook.Domain.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace SmartBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly LibroService _libroService;

        // Inyección de dependencia
        public LibrosController(LibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpPost]
        public ActionResult Crear(CrearLibroRequest request)
        {
            var libroCreado = _libroService.Crear(request);
            if (libroCreado is null)
            {
                return BadRequest();
            }
            return Created(string.Empty, libroCreado);
        }

        [HttpDelete("{id}")]
        public ActionResult Borrar(int id)
        {
            var borrado = _libroService.Borrar(id);
            if (!borrado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet]
        public ActionResult Consultar(string? nombre, string? nivel, string? tipo)
        {
            return Ok(_libroService.Consultar(nombre, nivel, tipo));
        }

        [HttpGet("{id}")]
        public ActionResult Consultar(int id)
        {
            var libro = _libroService.Consultar(id);
            if (libro is null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, ActualizarLibroRequest request)
        {
            var libro = _libroService.Actualizar(id, request);
            if (!libro)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}