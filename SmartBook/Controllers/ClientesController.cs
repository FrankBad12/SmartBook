using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBook.Application.Services;
using SmartBook.Domain.Dtos.Request;


namespace SmartBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    /*private readonly ClienteService _clienteService;

    //Esta es la inyección de dependencia
    public ClientesController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }
    [HttpPost]
    public ActionResult Crear(CrearClienteRequest request)
    {

        var cursoCreado = _clienteService.Crear(request);

        if (cursoCreado is null)
        {

            return BadRequest();
        }

        return Created(string.Empty, cursoCreado);
    }

    [HttpGet]
    public ActionResult Consultar(string? nombre, string? identificacion)
    {

        return Ok();
    }
    [HttpPut("{id}")]
    public ActionResult Actualizar(string id, ActualizarClienteRequest request)
    {

        var curso = _clienteService.Actualizar(id, request);

        if (!curso)
        {
            return NotFound();
        }

        return NoContent();
    }*/

}
