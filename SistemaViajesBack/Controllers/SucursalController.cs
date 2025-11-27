using Application.DTO.Sucursales;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace SistemaViajesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController(ISucursalService sucursalService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SucursalDTO>>> Get([FromQuery] FilterSucursalDTO filter)
        {
            return Ok(await sucursalService.GetAllSucursalesAsync(filter));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalDTO>> GetById(int id)
        {
            var sucursal = await sucursalService.GetSucursalByIdAsync(id);
            if (sucursal == null)
                return NotFound();
            return Ok(sucursal);
        }

        [HttpPost]
        public async Task<ActionResult<SucursalDTO>> Post([FromBody] CreateSucursalDTO createSucursal)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sucursal = await sucursalService.AddSucursalAsync(createSucursal);

            return CreatedAtAction("GetById", new { id = sucursal.Id }, sucursal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateSucursalDTO updateSucursal)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sucursal = await sucursalService.GetSucursalByIdAsync(updateSucursal.Id);

            if (sucursal == null)
                return NotFound();

            await sucursalService.UpdateSucursalAsync(updateSucursal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await sucursalService.DeleteSucursalAsync(id);
            return NoContent();
        }
    }
}
