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

            modelBuilder.Entity<TelAcudiente>().HasKey(t => new { t.IdAcudiente, t.Telefono }); //Definición de llaves PK compuestas
            modelBuilder.Entity<TelAcudiente>().HasOne(t => t.Acudiente)
                .WithMany(a => a.TelAcudiente)                                                  // 1 Acudiente tiene muchos teléfonos
                .HasForeignKey(t => t.IdAcudiente)                                              // Definir FK
                .OnDelete(DeleteBehavior.Cascade);                                              // Si elimina 1 Acudiente, los números asociados, también se borrarán

            modelBuilder.Entity<Factura>().HasKey(f => new { f.Id, f.IdServicio });             //Definición de llaves PK compuestas
            modelBuilder.Entity<Factura>().HasMany(f => f.Servicios)                             // 1 factura tiene muchos servicios
                .WithOne(s => s.Factura)                                                        // Los servicios asociados a una sola factura
                .OnDelete(DeleteBehavior.NoAction);                                             // Si elimina 1 factura, los servicios asociados, también se borrarán

            modelBuilder.Entity<Empleado>().HasOne(e => e.Usuario).WithOne()
                .HasForeignKey<Empleado>(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Gerente>().HasOne(g => g.Usuario).WithOne()
                .HasForeignKey<Gerente>(g => g.UsuarioId).OnDelete(DeleteBehavior.NoAction);

            //HasMany = Para muchos
            //HasOne = Para 1 
            //WithOne = Con 1
            //WithMany = tener muchos
        }
    }
}
