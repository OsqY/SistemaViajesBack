using Application.DTO.Viajes;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ViajeRepository(AppDbContext context) : IViajeRepository
    {
        public async Task<IEnumerable<Viaje>> GetAllAsync(FilterViajeDTO filter)
        {
            var viajes = context.Viajes.Include(e => e.Transportista).Include(e => e.Sucursal).AsNoTracking();

            if (filter.TransportistaId != null)
                viajes = viajes.Where(e => e.TransportistaId == filter.TransportistaId);

            if (filter.SucursalId != null)
                viajes = viajes.Where(e => e.SucursalId == filter.SucursalId);

            if (filter.MinDistanciaTotal != null)
                viajes = viajes.Where(e => e.DistanciaTotal >= filter.MinDistanciaTotal);

            if (filter.MaxDistanciaTotal != null)
                viajes = viajes.Where(e => e.DistanciaTotal <= filter.MaxDistanciaTotal);

            if (filter.MinTarifaTotal != null)
                viajes = viajes.Where(e => e.TarifaTotal >= filter.MinTarifaTotal);

            if (filter.MaxTarifaTotal != null)
                viajes = viajes.Where(e => e.TarifaTotal <= filter.MaxTarifaTotal);

            if (filter.MinFecha != null)
                viajes = viajes.Where(e => e.Fecha >= filter.MinFecha);

            if (filter.MaxFecha != null)
                viajes = viajes.Where(e => e.Fecha <= filter.MaxFecha);

            return await viajes.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).ToListAsync();
        }

        public Task<Viaje?> GetByIdAsync(int id)
        {
            return context.Viajes.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Viaje?> AddAsync(Viaje viaje)
        {
            await context.Viajes.AddAsync(viaje);
            await context.SaveChangesAsync();
            return viaje;
        }

        public async Task UpdateAsync(Viaje viaje)
        {
            context.Viajes.Update(viaje);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var viaje = await context.Viajes.FindAsync(id);
            if (viaje != null)
            {
                context.Viajes.Remove(viaje);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Viaje?> GetByIdWithDetailsAsync(int id)
        {
            return await context.Viajes
                .Include(v => v.UsuarioViajes)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Viaje>> GetViajesForReport(FilterReportDTO filter)
        {
            var viajes = context.Viajes.Include(v => v.Transportista)
                .Include(v => v.Sucursal).AsNoTracking();

            if (filter.MinTarifaTotal != null)
                viajes = viajes.Where(e => e.TarifaTotal >= filter.MinTarifaTotal);

            if (filter.MaxTarifaTotal != null)
                viajes = viajes.Where(e => e.TarifaTotal <= filter.MaxTarifaTotal);

            if (filter.MinFecha != null)
                viajes = viajes.Where(e => e.Fecha >= filter.MinFecha);

            if (filter.MaxFecha != null)
                viajes = viajes.Where(e => e.Fecha <= filter.MaxFecha);

            if (filter.TransportistaId != null)
                viajes = viajes.Where(e => e.TransportistaId == filter.TransportistaId);

            if (filter.SucursalId != null)
                viajes = viajes.Where(e => e.SucursalId == filter.SucursalId);

            return await viajes.ToListAsync();
        }
    }
}
