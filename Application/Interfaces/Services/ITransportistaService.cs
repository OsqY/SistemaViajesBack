using Application.DTO.Transportistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITransportistaService
    {
        Task<IEnumerable<TransportistaDTO>> GetAllTransportistasAsync(FilterTransportistaDTO filter);
        Task<TransportistaDTO?> GetTransportistaByIdAsync(int id);
        Task<TransportistaDTO?> AddTransportistaAsync(CreateTransportistaDTO createTransportista);
        Task UpdateTransportistaAsync(UpdateTransportistaDTO updateTransportista);
        Task DeleteTransportistaAsync(int id);
    }
}
