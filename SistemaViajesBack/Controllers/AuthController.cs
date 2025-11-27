
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using Application.DTO.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SistemaViajesBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(UserManager<Usuario> userManager) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<UsuarioForDropdownDTO>> GetUsuarioForDropdown()
        {
            var usuarios = await userManager.Users.Select(u => new UsuarioForDropdownDTO
            {
                Id = u.Id,
                Email = u.Email
            }).ToListAsync();

            return Ok(usuarios);
        }
    }
}
