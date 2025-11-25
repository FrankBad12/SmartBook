using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBook.Application.Services;
using SmartBook.Domain.Dtos.Request;

namespace SmartBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    //Esta es la inyección de dependencia
    public UsuariosController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    [HttpPost]
    public ActionResult Crear(CrearUsuarioRequest request)
    {




        var cursoCreado = _usuarioService.Crear(request);

        if (cursoCreado is null)
        {

            return BadRequest();
        }

        return Created(string.Empty, cursoCreado);
    }
    /*
    [HttpGet]
    public ActionResult Consultar(string? nombre)
    {

        return Ok();
    }
    [HttpPut("{usuario}")]
    public ActionResult Actualizar(string id, ActualizarUsuarioRequest request)
    {

        var curso = _usuarioService.Actualizar(id, request);

        if (!curso)
        {
            return NotFound();
        }

        return NoContent();
    }*/
}
