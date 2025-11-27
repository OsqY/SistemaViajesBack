using Application.DTO.Transportistas;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace SistemaViajesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportistaController(ITransportistaService transportistaService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TransportistaDTO>>> GetTransportistas([FromQuery]FilterTransportistaDTO filter)
        {
            return Ok(await transportistaService.GetAllTransportistasAsync(filter));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TransportistaDTO>> Get(int id)
        {
            var transportista = await transportistaService.GetTransportistaByIdAsync(id);

            if (transportista == null)
                return NotFound();

            return Ok(transportista);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateTransportistaDTO createTransportista)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var transportista = await transportistaService.AddTransportistaAsync(createTransportista);

            return Ok(transportista);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(UpdateTransportistaDTO updateTransportista)
        {
            await transportistaService.UpdateTransportistaAsync(updateTransportista);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await transportistaService.DeleteTransportistaAsync(id);
            return NoContent();
        }
    }
}
