using IForgor.Application.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);
{
    // Dependency Injection
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

    builder.Services.AddControllers();
}


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();