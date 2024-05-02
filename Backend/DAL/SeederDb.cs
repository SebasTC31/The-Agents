using Backend.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Backend.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;
        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync(); //Esta línea ayuda a poblar mi BD de forma automática
            await PoblarUsuariosAsync();
            await PoblarServiciosAsync();

            await _context.SaveChangesAsync();
        }

        private async Task PoblarUsuariosAsync()
        {
            if (!_context.Usuarios.Any())
            {
                _context.Usuarios.Add(new Usuario
                {
                    Id = 1001686119,
                    Nombre = "Diego Valencia",
                    Telefono = 3172648467,
                    Correo = "diego.valencia@gmail.com",
                    User = "diego.valencia",
                    Clave = "1234",
                    Sexo = 'M',
                    Edad = 20
                });

                _context.Usuarios.Add(new Usuario
                {
                    Id = 21158515,
                    Nombre = "Sebastian Torres",
                    Telefono = 3002686842,
                    Correo = "sebas.torres@gmail.com",
                    User = "sebas.torres",
                    Clave = "12345",
                    Sexo = 'M',
                    Edad = 20
                });
            }
        }

        public async Task PoblarServiciosAsync()
        {
            if (!_context.Servicios.Any())
            {
                var servicios = new List<Servicio>
                {
                    new Servicio
                    {
                        Fecha = DateTime.Now,
                        TipoServicio = "Consulta",
                        Precio = 35000,
                        Descripcion = "Consulta veterinaria estándar",
                        CantServicio = 1
                    },
                    new Servicio
                    {
                        Fecha = DateTime.Now,
                        TipoServicio = "Peluquería",
                        Precio = 40000,
                        Descripcion = "Corte de pelo y baño para mascotas",
                        CantServicio = 1
                    },
                    new Servicio
                    {
                        Fecha = DateTime.Now,
                        TipoServicio = "Baño General",
                        Precio = 30000,
                        Descripcion = "Baño y limpieza general para mascotas",
                        CantServicio = 1
                    },
                    new Servicio
                    {
                        Fecha = DateTime.Now,
                        TipoServicio = "Desparasitación",
                        Precio = 20000,
                        Descripcion = "Tratamiento para eliminar parásitos internos y externos",
                        CantServicio = 1
                    },
                    new Servicio
                    {
                        Fecha = DateTime.Now,
                        TipoServicio = "Vacunación",
                        Precio = 35000,
                        Descripcion = "Vacunación preventiva para mascotas",
                        CantServicio = 1
                    }
                };

                _context.Servicios.AddRange(servicios);
            }
        }


    }
}
