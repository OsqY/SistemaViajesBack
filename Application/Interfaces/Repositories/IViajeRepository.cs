using Application.DTO.Viajes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IViajeRepository
    {
        Task<IEnumerable<Viaje>> GetAllAsync(FilterViajeDTO filter);
        Task<Viaje?> GetByIdAsync(int id);
        Task<Viaje?> AddAsync(Viaje viaje);
        Task UpdateAsync(Viaje viaje);
        Task DeleteAsync(int id);
        Task<Viaje?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<Viaje>> GetViajesForReport(FilterReportDTO filter);
    }
}
