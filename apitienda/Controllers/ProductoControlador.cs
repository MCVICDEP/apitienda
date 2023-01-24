using apitienda.data.Repo;
using apitienda.modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apitienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoControlador : ControllerBase
    {
        private readonly IProductoRepo _productoRepo;

        public ProductoControlador(IProductoRepo productoRepo)
        {
            _productoRepo = productoRepo;
        }

        [HttpGet]

        public async Task<IActionResult> GetProductos()
        {
            return Ok(await _productoRepo.GetProductos());
        }

        [HttpGet("{idproducto}")]

        public async Task<IActionResult> GetDetalles(int id)
        {
            return Ok(await _productoRepo.GetDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertarProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _productoRepo.InsertarProducto(producto);
            return Created("Insertado", creado);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _productoRepo.UpdateProducto(producto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            await _productoRepo.EliminarProducto(new Producto { IdProducto = id });

            return NoContent();
        }
    }
}
