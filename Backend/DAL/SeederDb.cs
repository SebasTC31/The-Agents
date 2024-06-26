﻿using Backend.DAL.Entities;
using Microsoft.EntityFrameworkCore;
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
            await PoblarGerentesAsync();
            await PoblarEmpleadosAsync();
            await PoblarPacientesAsync();
            await PoblarProductosAsync();
            await PoblarAcudientesAsync();
            await PoblarFacturasAsync();

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

                _context.Usuarios.Add(new Usuario
                {
                    Id = 1001686120,
                    Nombre = "Maira Liseth",
                    Telefono = 3172648468,
                    Correo = "maira.liseth@gmail.com",
                    User = "maira.liseth",
                    Clave = "1234",
                    Sexo = 'F',
                    Edad = 34
                });

                _context.Usuarios.Add(new Usuario
                {
                    Id = 1001686123,
                    Nombre = "Meyer Usuga",
                    Telefono = 3172648471,
                    Correo = "meyer.usuga@gmail.com",
                    User = "meyer.usuga",
                    Clave = "1234",
                    Sexo = 'M',
                    Edad = 35
                });

                _context.Usuarios.Add(new Usuario
                {
                    Id = 1001686124,
                    Nombre = "Estefanía Alvarez",
                    Telefono = 3172648472,
                    Correo = "estefania.alvarez@gmail.com",
                    User = "estefania.alvarez",
                    Clave = "1234",
                    Sexo = 'F',
                    Edad = 22
                });

                _context.Usuarios.Add(new Usuario
                {
                    Id = 1001686125,
                    Nombre = "Ariana Granade",
                    Telefono = 3172648473,
                    Correo = "ariana.granade@gmail.com",
                    User = "ariana.granade",
                    Clave = "1234",
                    Sexo = 'F',
                    Edad = 27
                });

                _context.Usuarios.Add(new Usuario
                {
                    Id = 1001686126,
                    Nombre = "Inés Perado",
                    Telefono = 3172648474,
                    Correo = "ines.perado@gmail.com",
                    User = "ines.perado",
                    Clave = "1234",
                    Sexo = 'F',
                    Edad = 29
                });

                _context.Usuarios.Add(new Usuario
                {
                    Id = 1001686127,
                    Nombre = "Rosa Margarita Flores de Ramos",
                    Telefono = 3172648475,
                    Correo = "rosa.margarita@gmail.com",
                    User = "rosa.margarita",
                    Clave = "1234",
                    Sexo = 'F',
                    Edad = 32
                });
            }
        }

        private async Task PoblarServiciosAsync()       // public async Task PoblarServiciosAsync()         Usar como mejor se adecue, se hace cambio para que quede como "private"
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
        private async Task PoblarGerentesAsync()
        {
            if (!_context.Gerentes.Any())
            {
                var gerentes = new List<Gerente>
                {
                    new Gerente
                    {
                        UsuarioId = 1001686120,
                        FechaContrato = DateTime.Now
                    },
                    new Gerente
                    {
                        UsuarioId = 1001686119,
                        FechaContrato = DateTime.Now
                    },
                    new Gerente
                    {
                        UsuarioId = 21158515,
                        FechaContrato = DateTime.Now
                    },
                    new Gerente
                    {
                        UsuarioId = 1001686123,
                        FechaContrato = DateTime.Now
                    }
                };

                _context.Gerentes.AddRange(gerentes);
                await _context.SaveChangesAsync();
            }
        }

        private async Task PoblarEmpleadosAsync()
        {
            if (!_context.Empleados.Any())
            {
                var empleados = new List<Empleado>
                {
                    new Empleado
                    {
                        UsuarioId = 1001686124,
                        HoraInicio = "08:00",
                        HoraFin = "17:00",
                        TipoEmpleado = "Recepcionista",
                    },
                    new Empleado
                    {
                        UsuarioId = 1001686125,
                        HoraInicio = "09:00",
                        HoraFin = "18:00",
                        TipoEmpleado = "Veterinario"
                    },
                    new Empleado
                    {
                        UsuarioId = 1001686126,
                        HoraInicio = "10:00",
                        HoraFin = "19:00",
                        TipoEmpleado = "Auxiliar"
                    },
                    new Empleado
                    {
                        UsuarioId = 1001686127,
                        HoraInicio = "07:00",
                        HoraFin = "16:00",
                        TipoEmpleado = "Encargada de Limpieza"
                    }
                };

                _context.Empleados.AddRange(empleados);
                await _context.SaveChangesAsync();
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
                await _context.SaveChangesAsync();
            }
        }

        private async Task PoblarAcudientesAsync()
        {
            if (!_context.Acudientes.Any())
            {
                var pacientes = _context.Pacientes.ToList();
                var acudientes = new List<Acudiente>
                {
                    new Acudiente
                    {
                        Id = 1001686128,
                        Nombre = "Lucia Nuro",
                        Direccion = "Calle 123 #45-67",
                        Correo = "lucia.nuro@gmail.com",
                        Sexo = 'F',
                        Edad = 40,
                        IdPaciente = new List<Paciente> { pacientes[0] }, // Relacionando con el primer paciente
                        TelAcudiente = new List<TelAcudiente>
                        {
                            new TelAcudiente { Telefono = 3172648476 },
                            new TelAcudiente { Telefono = 3172648477 }
                        }
                    },
                    new Acudiente
                    {
                        Id = 1001686129,
                        Nombre = "Rihanna Álvarez",
                        Direccion = "Calle 234 #56-78",
                        Correo = "rihanna.alvarez@gmail.com",
                        Sexo = 'F',
                        Edad = 35,
                        IdPaciente = new List<Paciente> { pacientes[1] }, // Relacionando con el segundo paciente
                        TelAcudiente = new List<TelAcudiente>
                        {
                            new TelAcudiente { Telefono = 3172648478 },
                            new TelAcudiente { Telefono = 3172648479 }
                        }
                    },
                    new Acudiente
                    {
                        Id = 1001686130,
                        Nombre = "Camilo Alzate",
                        Direccion = "Calle 345 #67-89",
                        Correo = "camilo.alzate@gmail.com",
                        Sexo = 'M',
                        Edad = 38,
                        IdPaciente = new List<Paciente> { pacientes[2] }, // Relacionando con el tercer paciente
                        TelAcudiente = new List<TelAcudiente>
                        {
                            new TelAcudiente { Telefono = 3172648480 },
                            new TelAcudiente { Telefono = 3172648481 }
                        }
                    }
                };

                _context.Acudientes.AddRange(acudientes);
                await _context.SaveChangesAsync();
            }
        }

        private async Task PoblarFacturasAsync()
        {
            if (!_context.Facturas.Any())
            {
                var acudientes = await _context.Acudientes.ToListAsync();
                var servicios = await _context.Servicios.ToListAsync();

                var factura1 = new Factura
                {
                    Id = 1,
                    IdServicio = servicios[0].Id,
                    Fecha = DateTime.Now,
                    ValorTotal = 150000,
                    MetodoPago = "Efectivo",
                    Descripcion = "Consulta y vacunación para mascota",
                    Estado = "Pendiente",
                    Acudiente = acudientes[0],
                    Servicios = new List<Servicio> { servicios[0], servicios[4] }
                };

                var factura2 = new Factura
                {
                    Id = 1,
                    IdServicio = servicios[1].Id,
                    Fecha = DateTime.Now,
                    ValorTotal = 85000,
                    MetodoPago = "Tarjeta",
                    Descripcion = "Baño y corte de pelo para mascota",
                    Estado = "Pagada",
                    Acudiente = acudientes[1], 
                    Servicios = new List<Servicio> { servicios[1] }
                };

                var factura3 = new Factura
                {
                    Id = 1,
                    IdServicio = servicios[2].Id,
                    Fecha = DateTime.Now,
                    ValorTotal = 200000,
                    MetodoPago = "Transferencia",
                    Descripcion = "Consulta y desparasitación para mascota",
                    Estado = "Pagada",
                    Acudiente = acudientes[2], 
                    Servicios = new List<Servicio> { servicios[0], servicios[3] }
                };

                _context.Facturas.Add(factura1);
                _context.Facturas.Add(factura2);
                _context.Facturas.Add(factura3);
                await _context.SaveChangesAsync();
            }

        }
    }

}
