using Microsoft.EntityFrameworkCore;
using Mosaic.API;
using Mosaic.Persistence;
using Mosaic.Workers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Configuration.AddCommandLine(args);

builder.Services.AddDbContext<CanvasDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 33)) 
    ));


builder.Services.AddScoped<IBrush, Brush>();
builder.Services.AddScoped<IEye, Eye>();
builder.Services.AddTransient<IEndpoint, MosaicEndpoint>();

var app = builder.Build();

var endpoints = app.Services.GetServices<IEndpoint>().ToList();
endpoints.ForEach(e => e.RegisterRoutes(app));

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseCors(options =>
    options.WithOrigins("http://localhost:4200", "https://gentle-plant-06a96d810.2.azurestaticapps.net","https://www.collabcanvas.online")
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.Run();
