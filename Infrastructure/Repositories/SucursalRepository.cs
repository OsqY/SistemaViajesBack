using Application.DTO.Sucursales;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SucursalRepository(AppDbContext context) : ISucursalRepository
    {
        public async Task<IEnumerable<Sucursal>> GetAllAsync(FilterSucursalDTO filter)
        {
            var sucursales = context.Sucursales.AsNoTracking();

            if (filter.NombreFilter != null)
                sucursales = sucursales.Where(e => e.Nombre.ToLower().Contains(filter.NombreFilter));

            if (filter.DireccionFilter != null)
                sucursales = sucursales.Where(e => e.Direccion.ToLower().Contains(filter.DireccionFilter));
            return await sucursales.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();
        }

        public async Task<Sucursal?> GetByIdAsync(int id)
        {
            return await context.Sucursales.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Sucursal?> AddAsync(Sucursal sucursal)
        {
            await context.Sucursales.AddAsync(sucursal);
            await context.SaveChangesAsync();
            return sucursal;
        }


        public async Task UpdateAsync(Sucursal sucursal)
        {
            context.Sucursales.Update(sucursal);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sucursal = await context.Sucursales.FindAsync(id);
            if (sucursal != null)
            {
                context.Sucursales.Remove(sucursal);
                await context.SaveChangesAsync();
            }
                
        }


    }
}
