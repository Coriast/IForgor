using ErrorOr;
using IForgor.Application.Common.Interfaces.Persistence;
using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate;
using MediatR;

namespace IForgor.Application.Fields.Commands.CreateField;
public class CreateFieldCommandHandler : IRequestHandler<CreateFieldCommand, ErrorOr<Field>>
{
    private readonly IFieldRepository _fieldRepository;

    public CreateFieldCommandHandler(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task<ErrorOr<Field>> Handle(CreateFieldCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var field = Field.Create(request.Title, DeskId.Create(Guid.Parse(request.DeskId)));

        _fieldRepository.AddFieldToDesk(field, field.DeskId);

        return field;
    }
}
