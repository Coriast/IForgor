using ErrorOr;
using IForgor.Domain.FieldAggregate;
using MediatR;

namespace IForgor.Application.Fields.Commands.CreateField;
public record CreateFieldCommand(string Title, string DeskId) : IRequest<ErrorOr<Field>>;
