using Application.DTO.Sucursales;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ISucursalRepository
    {
        Task<IEnumerable<Sucursal>> GetAllAsync(FilterSucursalDTO filter);
        Task<Sucursal?> GetByIdAsync(int id);
        Task<Sucursal?> AddAsync(Sucursal sucursal);
        Task UpdateAsync(Sucursal sucursal);
        Task DeleteAsync(int id);
    }
}
