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

    [HttpDelete]
    public ActionResult Borrar(string id)
    {
        var borrado = _usuarioService.Borrar(id);
        if (!borrado)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet]
    public ActionResult Consultar(string? nombre, string? email)
    {
        return Ok(_usuarioService.Consultar(nombre, email));
    }

    [HttpGet("{id}")]
    public ActionResult Consultar(string id)
    {
        var usuario = _usuarioService.Consultar(id);
        if (usuario is null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public ActionResult Actualizar(string id, ActualizarUsuarioRequest request)
    {
        var usuario = _usuarioService.Actualizar(id, request);
        if (!usuario)
        {
            return NotFound();
        }
        return NoContent();
    }
}
