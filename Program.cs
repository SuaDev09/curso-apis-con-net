using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
//Interfaz, dependencia ~~Cada vez que se llene la interfaz, se creara un objeto de la dependencia internamente
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
//builder.Services.AddScoped(); //Se crea una nueva instancia de la dependencia pero al nivel de controlador 
//builder.Services.AddSingleton(); se crea una unica instancia de esa depencia a nivel de toda la API ~~No es recomendable~~
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

//app.UseWelcomePage();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
