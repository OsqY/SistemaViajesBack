using Application.DTO.Transportistas;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ITransportistaRepository
    {
        Task<IEnumerable<Transportista>> GetAllAsync(FilterTransportistaDTO filter);
        Task<Transportista?> GetByIdAsync(int id);
        Task<Transportista?> AddAsync(Transportista transportista);
        Task UpdateAsync(Transportista transportista);
        Task DeleteAsync(int id);
    }
}
