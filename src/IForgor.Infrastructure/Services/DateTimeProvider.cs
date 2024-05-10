using IForgor.Application.Interfaces.Services;

namespace IForgor.Infrastructure.Services;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
