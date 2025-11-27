using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<Usuario>(options)
    {
        public DbSet<UsuarioViaje> UsuariosViajes => Set<UsuarioViaje>();
        public DbSet<Transportista> Transportistas => Set<Transportista>();
        public DbSet<Viaje> Viajes => Set<Viaje>();
        public DbSet<Sucursal> Sucursales => Set<Sucursal>();
        public DbSet<SucursalUsuario> SucursalUsuarios => Set<SucursalUsuario>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Viaje>(entity =>
            {
                entity.HasOne(v => v.Transportista)
                      .WithMany(t => t.Viajes)
                      .HasForeignKey(v => v.TransportistaId)
                      .OnDelete(DeleteBehavior.Restrict); 

                entity.HasOne(v => v.Sucursal)
                      .WithMany() 
                      .HasForeignKey(v => v.SucursalId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(v => v.TarifaTotal).HasPrecision(18, 2);
                entity.Property(v => v.DistanciaTotal).HasPrecision(3, 2);
            });

            builder.Entity<UsuarioViaje>(entity =>
            {
                entity.HasKey(uv => new { uv.ViajeId, uv.UsuarioId });

                entity.HasOne(uv => uv.Viaje)
                      .WithMany(v => v.UsuarioViajes)
                      .HasForeignKey(uv => uv.ViajeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(uv => uv.Usuario)
                      .WithMany()
                      .HasForeignKey(uv => uv.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict); 

                entity.HasOne(uv => uv.CreatorUser)
                      .WithMany()
                      .HasForeignKey(uv => uv.CreatorUserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(uv => uv.Tarifa).HasPrecision(18, 2);
                entity.Property(uv => uv.Distancia).HasPrecision(2, 2);
            });
           
            builder.Entity<SucursalUsuario>(entity =>
            {
                entity.HasKey(su => new { su.SucursalId, su.UsuarioId });

                entity.HasOne(su => su.Sucursal)
                      .WithMany()
                      .HasForeignKey(su => su.SucursalId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(su => su.Usuario)
                      .WithMany()
                      .HasForeignKey(su => su.UsuarioId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(su => su.Distancia).HasPrecision(2, 2);
            });

            builder.Entity<Transportista>(entity =>
            {
                entity.Property(t => t.Tarifa).HasPrecision(18, 2);
            });

            builder.Entity<Usuario>(entity =>
            {
                entity.Property(u => u.DistanciaCasa).HasPrecision(2, 2);
            });
        }
    }
}