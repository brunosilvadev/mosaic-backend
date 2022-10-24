var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IEndpoint, MosaicEndpoint>();
builder.Services.AddSingleton<Mosaic.Persistence.ITemporaryDbProvider, Mosaic.Persistence.TemporaryDbProvider>();


var app = builder.Build();

var endpoints = app.Services.GetServices<IEndpoint>().ToList();

endpoints.ForEach(e => e.RegisterRoutes(app));

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
