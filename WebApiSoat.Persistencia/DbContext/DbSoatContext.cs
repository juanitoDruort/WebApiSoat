using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Modelos;

namespace WebApiSoat.Persistencia
{
    public class DbSoatContext : DbContext
    {
        public DbSoatContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Soat> Soat { get; set; }
        public DbSet<CiudadVenta> CiudadVenta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(E =>
            {
                E.ToTable("Cliente", "dbo");
                E.HasKey(c => c.IdCliente);
                E.HasMany(c => c.Soats)
                .WithOne(c => c.Cliente)
                .HasForeignKey(pk => pk.IdCliente);
            });

            modelBuilder.Entity<Cliente>()
            .Property(f => f.IdCliente)            
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Soat>(E =>
            {
                E.ToTable("Soat", "dbo");
                E.HasKey(c => c.IdSoat);
                E.HasOne(c => c.Cliente)
                .WithMany(c => c.Soats)
                .HasForeignKey(pk => pk.IdCliente);
            });

            modelBuilder.Entity<Soat>()
            .Property(f => f.IdSoat).ValueGeneratedOnAdd();
            modelBuilder.Entity<Soat>()
            .Property(f => f.IdCliente).HasColumnName("IdCliente");

            modelBuilder.Entity<CiudadVenta>(E =>
            {
                E.ToTable("CiudadVenta", "dbo");
                E.HasKey(c => c.IdCiudadVenta);
            });

            modelBuilder.Entity<CiudadVenta>()
           .Property(f => f.IdCiudadVenta).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }

    }
}
