using IForgor.Application.Fields.Commands.CreateField;
using IForgor.Contracts.Fields;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IForgor.API.Controllers;

[Route("desk/{DeskId}/fields")]
public class FieldsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public FieldsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateField(CreateFieldRequest request, string DeskId)
    {
        var command = _mapper.Map<CreateFieldCommand>((request, DeskId));

        var createFieldResult = await _mediator.Send(command);

        return createFieldResult.Match(
            createFieldResult => Ok(_mapper.Map<FieldResponse>(createFieldResult)),
            errors => Problem(errors)
        );
    }
}
