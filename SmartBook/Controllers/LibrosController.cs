using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBook.Application.Services;
using SmartBook.Domain.Dtos.Request;

namespace SmartBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibrosController : ControllerBase
{
    /*private readonly LibroService _libroService;

    //Esta es la inyección de dependencia
    public LibrosController(LibroService libroService)
    {
        _libroService = libroService;
    }
    [HttpPost]
    public ActionResult Crear(CrearLibroRequest request)
    {

        var cursoCreado = _libroService.Crear(request);

        if (cursoCreado is null)
        {

            return BadRequest();
        }

        return Created(string.Empty, cursoCreado);
    }
    

    [HttpGet]
    public ActionResult Consultar(string? nombre, int? docenteId)
    {

        return Ok(_libroService.Consultar(nombre, docenteId));
    }


    [HttpGet("{id}")]
    public ActionResult Consultar(string id)
    {
        var curso = _libroService.Consultar(id);

        if (curso is null)
        {

            return NotFound();
        }

        return Ok(curso);
    }



    [HttpPut("{id}")]
    public ActionResult Actualizar(string id, ActualizarLibroRequest request)
    {

        var curso = _libroService.Actualizar(id, request);

        if (!curso)
        {
            return NotFound();
        }

        return NoContent();
    }
    */
}
