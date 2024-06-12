using AdmTarea.BW.CU;
using AdmTarea.BW.Interfaces.BW;
using AdmTarea.BW.Interfaces.DA;
using AdmTarea.DA.Acciones;
using AdmTarea.DA.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


//Inyecci�n de dependencias
builder.Services.AddTransient<IGestionarTareaBW, GestionarTareaBW>();
builder.Services.AddTransient<IGestionarTareaDA, GestionarTareaDA>();

builder.Services.AddTransient<IGestionarUsuarioBW, GestionarUsuarioBW>();
builder.Services.AddTransient<IGestionarUsuarioDA, GestionarUsuarioDA>();

builder.Services.AddTransient<IGestionarCarritoBW, GestionarCarritoBW>();
builder.Services.AddTransient<IGestionarCarritoDA, GestionarCarritoDA>();

//Conexi�n a BD
builder.Services.AddDbContext<AdmTareaContext>(options =>
{
    // Usar la cadena de conexi�n desde la configuraci�n
    var connectionString = "Server=tcp:163.178.107.10;Initial Catalog=ProyectoLenguajes;Persist Security Info=False;User Id=laboratorios;Password=TUy&)&nfC7QqQau.%278UQ24/=%;TrustServerCertificate=True";
    options.UseSqlServer(connectionString);
    // Otros ajustes del contexto de base de datos pueden ser configurados aqu�, si es necesario
});

builder.Services.AddDbContext<UsuarioContext>(options =>
{
    // Usar la cadena de conexi�n desde la configuraci�n
    var connectionString = "Server=tcp:163.178.107.10;Initial Catalog=ProyectoLenguajes;Persist Security Info=False;User Id=laboratorios;Password=TUy&)&nfC7QqQau.%278UQ24/=%;TrustServerCertificate=True";
    options.UseSqlServer(connectionString);
    // Otros ajustes del contexto de base de datos pueden ser configurados aqu�, si es necesario
});


builder.Services.AddDbContext<CarritoContext>(options =>
{
    // Usar la cadena de conexi�n desde la configuraci�n
    var connectionString = "Server=tcp:163.178.107.10;Initial Catalog=ProyectoLenguajes;Persist Security Info=False;User Id=laboratorios;Password=TUy&)&nfC7QqQau.%278UQ24/=%;TrustServerCertificate=True";
    options.UseSqlServer(connectionString);
    // Otros ajustes del contexto de base de datos pueden ser configurados aqu�, si es necesario
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Aplicar la pol�tica de CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
