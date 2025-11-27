using Application.DTO.UsuarioViajes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUsuarioViajeRepository
    {
        Task<IEnumerable<UsuarioViaje>> GetAllAsync(FilterUsuarioViajeDTO filter);
        Task<UsuarioViaje?> GetByIdAsync(int viajeId, string usuarioId);
        Task<UsuarioViaje?> AddAsync(UsuarioViaje usuarioViaje);
        Task UpdateAsync(UsuarioViaje usuarioViaje);
        Task DeleteAsync(int viajeId, string usuarioId);
    }
}
