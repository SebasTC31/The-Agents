using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<DataBaseContext>(o =>
//{
//    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

//builder.Services.AddTransient<SeederDb>();

//builder.Services.AddControllers().AddJsonOptions(x =>
//                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

//Esto me llama el método SeederAsync() para poder poblar las tablas al momento de correr la app.
//SeederData();
//void SeederData()
//{
//    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

//    using (IServiceScope? scope = scopedFactory.CreateScope())
//    {
//        SeederDb? service = scope.ServiceProvider.GetService<SeederDb>();
//        service.SeederAsync().Wait();
//    }
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
