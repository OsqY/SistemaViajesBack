using Application.DTO.UsuarioViajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUsuarioViajeService
    {
        Task<IEnumerable<UsuarioViajeDTO>> GetAllUsuarioViajesAsync(FilterUsuarioViajeDTO filter);
        Task<UsuarioViajeDTO?> GetUsuarioViajeByIdAsync(int viajeId, string usuarioId);
        Task<UsuarioViajeDTO?> AddUsuarioViajeAsync(CreateUsuarioViajeDTO createUsuarioViaje);
        Task UpdateUsuarioViajeAsync(UpdateUsuarioViajeDTO updateUsuarioViaje);
        Task DeleteUsuarioViajeAsync(int viajeId, string UsuarioId);
    }
}
