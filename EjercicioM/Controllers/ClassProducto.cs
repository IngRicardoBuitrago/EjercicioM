
using EjercicioM.Application;
using EjercicioM.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioM.Controllers;


[ApiController]
[Route("api/productos")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _service;
        public ProductosController(IProductoService service)
        {
            _service = service;
        }


    // GET api/productos
    [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ObtenerTodosAsync());
        }




    // GET api/productos/5
    [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _service.ObtenerPorIdAsync(id);
            return producto == null ? NotFound() : Ok(producto);
        }

        // POST api/productos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            await _service.CrearAsync(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.ID }, producto);
        }

        // PUT api/productos/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
        {
            if (id != producto.ID)
                return BadRequest("El id no coincide con el producto");

            try
            {
                await _service.ActualizarAsync(id, producto);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE api/productos/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.EliminarAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    

}
