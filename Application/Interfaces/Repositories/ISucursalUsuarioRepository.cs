using Application.DTO.SucursalUsuarios;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ISucursalUsuarioRepository
    {
        Task<IEnumerable<SucursalUsuario>> GetAllAsync(FilterSucursalUsuarioDTO filter);
        Task<SucursalUsuario?> GetByIdAsync(int sucursalId, string usuarioId);
        Task<SucursalUsuario?> AddAsync(SucursalUsuario sucursalUsuario);
        Task UpdateAsync(SucursalUsuario sucursalUsuario);
        Task DeleteASync(int sucursalId, string usuarioId);
    }
}
