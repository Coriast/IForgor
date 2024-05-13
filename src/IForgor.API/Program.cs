using IForgor.API.Common.Errors;
using IForgor.Application;
using IForgor.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, IForgorProblemDetailsFactory>();
}


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();