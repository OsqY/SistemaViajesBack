using Application.DTO.SucursalUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ISucursalUsuarioService
    {
        Task<IEnumerable<SucursalUsuarioDTO>> GetAllSucursalUsuariosAsync(FilterSucursalUsuarioDTO filter);
        Task<SucursalUsuarioDTO?> GetSucursalUsuarioAsync(int sucursalId, string usuarioId);
        Task<SucursalUsuarioDTO?> AddSucursalUsuarioAsync(CreateSucursalUsuarioDTO createSucursalUsuario);
        Task UpdateSucursalUsuarioAsync(UpdateSucursalUsuarioDTO updateSucursalUsuario);
        Task DeleteSucursalUsuarioAsync(int sucursalId, string usuarioId);
    }
}
