using SmartBook.Application.Services;
using SmartBook.Domain.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace SmartBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        // Inyección de dependencia
        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public ActionResult Crear(CrearClienteRequest request)
        {
            var clienteCreado = _clienteService.Crear(request);
            if (clienteCreado is null)
            {
                return BadRequest();
            }
            return Created(string.Empty, clienteCreado);
        }

        [HttpDelete("{id}")]
        public ActionResult Borrar(int id)
        {
            var borrado = _clienteService.Borrar(id);
            if (!borrado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet]
        public ActionResult Consultar(string? nombre, string? identificacion, string? email)
        {
            return Ok(_clienteService.Consultar(nombre, identificacion, email));
        }

        [HttpGet("{id}")]
        public ActionResult Consultar(int id)
        {
            var cliente = _clienteService.Consultar(id);
            if (cliente is null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, ActualizarClienteRequest request)
        {
            var cliente = _clienteService.Actualizar(id, request);
            if (!cliente)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}