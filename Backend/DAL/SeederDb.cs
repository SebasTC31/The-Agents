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
        
        public async Task PoblarProductosAsync()
        {
            if (!_context.Productos.Any())
            {
                var productos = new List<Producto>
                {
                    new Producto
                    {
                        Nombre = "Desparacitante",
                        Precio = 15000,
                        CantUso = 1,
                        Descripcion = "Tratamiento para eliminar parásitos internos y externos"
                    },
                    new Producto
                    {
                        Nombre = "Vacuna pentavalente",
                        Precio = 25000,
                        CantUso = 1,
                        Descripcion = "Vacuna que protege contra cinco enfermedades comunes en mascotas"
                    },
                    new Producto
                    {
                        Nombre = "Shampoo antipulgas",
                        Precio = 12000,
                        CantUso = 1,
                        Descripcion = "Shampoo especializado para eliminar pulgas en mascotas"
                    },
                    new Producto
                    {
                        Nombre = "Loción canina o felina",
                        Precio = 18000,
                        CantUso = 1,
                        Descripcion = "Loción para el cuidado de la piel en perros o gatos"
                    },
                    new Producto
                    {
                        Nombre = "Suero oral",
                        Precio = 10000,
                        CantUso = 1,
                        Descripcion = "Suero para la rehidratación en casos de deshidratación en mascotas"
                    }

                };

                _context.Productos.AddRange(productos);
            }
        }
        private async Task PoblarEmpleadosYGerentesAsync()
        {
            if (!_context.Empleados.Any())
            {
                var gerentes = new List<Gerente>
                {
                    new Gerente
                    {
                        Id = 1000001,
                        UsuarioId = 1000011, 
                        FechaContrato = DateTime.Now.AddDays(-30) // Fecha de contrato para el primer gerente
                    },
                    new Gerente
                    {
                        Id = 1000002,
                        UsuarioId = 1000012,
                        FechaContrato = DateTime.Now.AddDays(-15) // Fecha de contrato para el segundo gerente
                    }
                };

                _context.Gerentes.AddRange(gerentes);

                var empleados = new List<Empleado>
                {
                    new Empleado
                    {
                        Id = 2000001,
                        UsuarioId = 2000011, 
                        Sueldo = 1500000, 
                        TipoEmpleado = "Veterinario",
                        HoraInicio = "08:00",
                        HoraFin = "17:00",
                        Usuario = new Usuario
                        {
                            Id = 2000021, 
                            Nombre = "Juan Perez",
                            Telefono = 3001234567,
                            Correo = "juan.perez@gmail.com",
                            User = "juan.perez",
                            Clave = "1234",
                            Sexo = 'M',
                            Edad = 35
                        }
                    },
                    new Empleado
                    {
                        Id = 2000002,
                        UsuarioId = 2000012, 
                        Sueldo = 1200000, 
                        TipoEmpleado = "Auxiliar",
                        HoraInicio = "09:00",
                        HoraFin = "18:00",
                        Usuario = new Usuario
                        {
                            Id = 2000022, 
                            Nombre = "Maria Lopez",
                            Telefono = 3109876543,
                            Correo = "maria.lopez@gmail.com",
                            User = "maria.lopez",
                            Clave = "12345",
                            Sexo = 'F',
                            Edad = 28
                        }
                    },
                    new Empleado
                    {
                        Id = 2000003,
                        UsuarioId = 2000013,
                        Sueldo = 1100000, 
                        TipoEmpleado = "Recepcionista",
                        HoraInicio = "07:00",
                        HoraFin = "16:00",
                        Usuario = new Usuario
                        {
                            Id = 2000023, 
                            Nombre = "Carlos Ramirez",
                            Telefono = 3155555555,
                            Correo = "carlos.ramirez@gmail.com",
                            User = "carlos.ramirez",
                            Clave = "123456",
                            Sexo = 'M',
                            Edad = 30
                        }
                    },
                    new Empleado
                    {
                        Id = 2000004,
                        UsuarioId = 2000014,
                        Sueldo = 1000000,
                        TipoEmpleado = "Auxiliar",
                        HoraInicio = "10:00",
                        HoraFin = "19:00",
                        Usuario = new Usuario
                        {
                            Id = 2000024, 
                            Nombre = "Ana Martinez",
                            Telefono = 3188888888,
                            Correo = "ana.martinez@gmail.com",
                            User = "ana.martinez",
                            Clave = "1234567",
                            Sexo = 'F',
                            Edad = 25
                        }
                    }
                };

                _context.Empleados.AddRange(empleados);
            }
        }

        public async Task PoblarPacientesAsync()
        {
            if (!_context.Pacientes.Any())
            {
                var pacientes = new List<Paciente>
                {
                    new Paciente
                    {
                        Nombre = "Luna",
                        Edad = 3,
                        Sexo = 'H',
                        Peso = 12.5f,
                        Raza = "Labrador Retriever",
                        TipoAnimal = "Perro"
                    },
                    new Paciente
                    {
                        Nombre = "Simba",
                        Edad = 2,
                        Sexo = 'M',
                        Peso = 7.8f,
                        Raza = "Persa",
                        TipoAnimal = "Gato"
                    },
                    new Paciente
                    {
                        Nombre = "Rocky",
                        Edad = 5,
                        Sexo = 'M',
                        Peso = 20.3f,
                        Raza = "Bulldog",
                        TipoAnimal = "Perro"
                    },
                    new Paciente
                    {
                        Nombre = "Coco",
                        Edad = 1,
                        Sexo = 'H',
                        Peso = 4.2f,
                        Raza = "Siames",
                        TipoAnimal = "Gato"
                    },
                    new Paciente
                    {
                        Nombre = "Milo",
                        Edad = 6,
                        Sexo = 'M',
                        Peso = 9.7f,
                        Raza = "Yorkshire Terrier",
                        TipoAnimal = "Perro"
                    },
                    new Paciente
                    {
                        Nombre = "Bella",
                        Edad = 4,
                        Sexo = 'H',
                        Peso = 15.6f,
                        Raza = "Golden Retriever",
                        TipoAnimal = "Perro"
                    },
                    new Paciente
                    {
                        Nombre = "Luna",
                        Edad = 2,
                        Sexo = 'H',
                        Peso = 6.3f,
                        Raza = "Ragdoll",
                        TipoAnimal = "Gato"
                    }
                };

                _context.Pacientes.AddRange(pacientes);
            }
        }
    }
}
