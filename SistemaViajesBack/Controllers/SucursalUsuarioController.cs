using Application.DTO.SucursalUsuarios;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace SistemaViajesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalUsuarioController(ISucursalUsuarioService sucursalUsuarioService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SucursalUsuarioDTO>>> Get([FromQuery] FilterSucursalUsuarioDTO filter)
        {
            return Ok(await sucursalUsuarioService.GetAllSucursalUsuariosAsync(filter));
        }

        [HttpGet("{sucursalId}/{usuarioId}")]
        public async Task<ActionResult<SucursalUsuarioDTO>> Get(int sucursalId, string usuarioId)
        {
            var sucursalUsuario = await sucursalUsuarioService.GetSucursalUsuarioAsync(sucursalId, usuarioId);
            if (sucursalUsuario == null)
            {
                return NotFound();
            }
            return Ok(sucursalUsuario);
        }
        [HttpPost]
        public async Task<ActionResult<SucursalUsuarioDTO>> Post([FromBody] CreateSucursalUsuarioDTO createSucursalUsuario)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await sucursalUsuarioService.AddSucursalUsuarioAsync(createSucursalUsuario);
            return Ok();
        }

        [HttpPut("{sucursalId}/{usuarioId}")]
        public async Task<IActionResult> Put([FromBody] UpdateSucursalUsuarioDTO updateSucursalUsuario, int sucursalId, string usuarioId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                await sucursalUsuarioService.UpdateSucursalUsuarioAsync(updateSucursalUsuario);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpDelete("{sucursalId}/{usuarioId}")]
        public async Task<IActionResult> Delete(int sucursalId, string usuarioId)
        {
            try
            {
                await sucursalUsuarioService.DeleteSucursalUsuarioAsync(sucursalId, usuarioId);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
