using IForgor.API;
using IForgor.Application;
using IForgor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();