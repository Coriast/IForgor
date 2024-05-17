using ErrorOr;
using IForgor.Domain.DeskAggregate;
using MediatR;

namespace IForgor.Application.Desks.Commands.CreateDesk;
public record CreateDeskCommand(string Title, string UserId) : IRequest<ErrorOr<Desk>>;
