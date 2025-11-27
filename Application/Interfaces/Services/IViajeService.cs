using Application.DTO.Viajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IViajeService
    {
        Task<IEnumerable<ViajeDTO>> GetAllViajesAsync(FilterViajeDTO filter);
        Task<ViajeDTO?> GetViajeByIdAsync(int id);
        Task<ViajeDTO?> AddViajeAsync(CreateViajeDTO createViaje);
        Task UpdateViajeAsync(UpdateViajeDTO updateViaje);
        Task DeleteViajeAsync(int id);
        Task<IEnumerable<ViajeReportDTO>> GetViajesForReport(FilterReportDTO filter);
    }
}
