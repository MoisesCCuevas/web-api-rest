using Microsoft.EntityFrameworkCore;
using web_api_rest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add dependency injection before  building the app
// AddScoped: A new instance is created for each request
string connectionString = builder.Configuration.GetConnectionString("TareasDb");
builder.Services.AddDbContext<TareasContext>(options =>
  options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
builder.Services.AddScoped<IHwService, HwService>();
// AddSingleton: A single instance is created for the application
//builder.Services.AddSingleton();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// custom middleware
//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
