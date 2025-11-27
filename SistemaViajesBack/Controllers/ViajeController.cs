using Application.DTO.Viajes;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaViajesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Gerente")]
    public class ViajeController(IViajeService viajeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViajeDTO>>> Get([FromQuery] FilterViajeDTO filterViaje)
        {
            return Ok(await viajeService.GetAllViajesAsync(filterViaje));
        }

        [HttpGet("report")]
        public async Task<ActionResult<IEnumerable<ViajeReportDTO>>> GetViajesForReport([FromQuery] FilterReportDTO filter)
        {
            var viajes = await viajeService.GetViajesForReport(filter);

            return Ok(viajes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViajeDTO>> GetById(int id)
        {
            var viaje = await viajeService.GetViajeByIdAsync(id);

            if (viaje == null)
            {
                return NotFound();
            }

            return Ok(viaje);
        }

        [HttpPost]
        public async Task<ActionResult<ViajeDTO>> Post([FromBody] CreateViajeDTO createViaje)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await viajeService.AddViajeAsync(createViaje);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateViajeDTO updateViaje, int id)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest();

                await viajeService.UpdateViajeAsync(updateViaje);

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await viajeService.DeleteViajeAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
