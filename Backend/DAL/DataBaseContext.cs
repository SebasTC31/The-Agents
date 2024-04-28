using Backend.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Backend.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Requiere> Requieres { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Acudiente> Acudientes { get; set; }
        public DbSet<TelAcudiente> TelAcudientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasIndex(u => u.User).IsUnique();
            modelBuilder.Entity<Factura>().HasKey(f => new { f.Id, f.IdServicio });
            modelBuilder.Entity<TelAcudiente>().HasKey(t => new { t.IdAcudiente, t.Telefono });
        }
    }
}
