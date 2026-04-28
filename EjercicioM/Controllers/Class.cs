
using EjercicioM.Application;
using EjercicioM.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioM.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    // GET api/clientes
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.ObtenerTodosAsync());
    }

    // GET api/clientes/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var cliente = await _service.ObtenerPorIdAsync(id);
        return cliente == null ? NotFound() : Ok(cliente);
    }

    // POST api/clientes
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Cliente cliente)
    {
        var creado = await _service.CrearAsync(cliente);
        return CreatedAtAction(nameof(Get), new { id = creado.ClienteID }, creado);
    }

    // PUT api/clientes/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
    {
        var ok = await _service.ActualizarAsync(id, cliente);
        return ok ? NoContent() : NotFound();
    }

    // DELETE api/clientes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.EliminarAsync(id);
        return ok ? NoContent() : NotFound();
    }
}
