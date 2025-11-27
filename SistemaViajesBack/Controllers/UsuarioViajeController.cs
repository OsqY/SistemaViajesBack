using Application.DTO.UsuarioViajes;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaViajesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Gerente")]
    public class UsuarioViajeController(IUsuarioViajeService usuarioViajeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioViajeDTO>>> Get([FromQuery] FilterUsuarioViajeDTO filter)
        {
            var result = await usuarioViajeService.GetAllUsuarioViajesAsync(filter);
            return Ok(result);
        }

        [HttpGet("{viajeId}/{usuarioId}")]
        public async Task<ActionResult<UsuarioViajeDTO>> Get(int viajeId, string usuarioId)
        {
            var usuarioViaje = await usuarioViajeService.GetUsuarioViajeByIdAsync(viajeId, usuarioId);
            if (usuarioViaje == null)
                return NotFound();

            return Ok(usuarioViaje);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioViajeDTO>> Post([FromBody] CreateUsuarioViajeDTO createUsuarioViaje)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await usuarioViajeService.AddUsuarioViajeAsync(createUsuarioViaje);
            return Ok();
        }

        [HttpPut("{viajeId}/{usuarioId}")]
        public async Task<IActionResult> Put([FromBody] UpdateUsuarioViajeDTO updateUsuarioViaje, int viajeId, string usuarioId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                await usuarioViajeService.UpdateUsuarioViajeAsync(updateUsuarioViaje);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpDelete("{viajeId}/{usuarioId}")]
        public async Task<IActionResult> Delete(int viajeId, string usuarioId)
        {
            try
            {
                await usuarioViajeService.DeleteUsuarioViajeAsync(viajeId, usuarioId);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
