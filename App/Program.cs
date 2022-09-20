var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.MapGet("/bla", testando);

string testando() { return "Hello World";}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
