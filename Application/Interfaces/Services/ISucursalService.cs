using Application.DTO.Sucursales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ISucursalService
    {
        Task<IEnumerable<SucursalDTO>> GetAllSucursalesAsync(FilterSucursalDTO filter);
        Task<SucursalDTO?> GetSucursalByIdAsync(int id);
        Task<SucursalDTO?> AddSucursalAsync(CreateSucursalDTO createSucursal);
        Task UpdateSucursalAsync(UpdateSucursalDTO updateSucursal);
        Task DeleteSucursalAsync(int id);
    }
}
