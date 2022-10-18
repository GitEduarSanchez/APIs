using WebAPI.Models;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregamos los servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlServer<tiendaContext>(builder.Configuration.GetConnectionString("azure"));
builder.Services.AddDbContext<tiendaContext>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<CategoriaService>();

// configuramos el cors para hacerlo libre a las peticiones de cualquier host
string CorsConfiguration = "_CorsConfiguration";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsConfiguration, builder =>
    {
        builder.WithOrigins("*");
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(CorsConfiguration);
app.Run();
