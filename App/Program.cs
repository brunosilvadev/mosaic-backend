using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddTransient<IEndpoint, MosaicEndpoint>();
builder.Services.AddSingleton<Mosaic.Persistence.ITemporaryDbProvider, Mosaic.Persistence.TemporaryDbProvider>();
builder.Services.AddSingleton<Mosaic.Workers.IBrush, Mosaic.Workers.Brush>();
builder.Services.AddSingleton<Mosaic.Workers.IEye, Mosaic.Workers.Eye>();


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
    options.WithOrigins("http://localhost:4200", "https://gentle-plant-06a96d810.2.azurestaticapps.net/")
    .AllowAnyMethod()
    .AllowAnyHeader()
);


app.Run();
