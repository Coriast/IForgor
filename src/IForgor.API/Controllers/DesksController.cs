using IForgor.Application.Desks.Commands.CreateDesk;
using IForgor.Contracts.Desks;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IForgor.API.Controllers;

[Route("users/{UserId}/desks")]
public class DesksController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public DesksController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDesk(CreateDeskRequest request, string UserId)
    {
        var command = _mapper.Map<CreateDeskCommand>((request, UserId));

        var createDeskResult = await _mediator.Send(command);

        return createDeskResult.Match(
            createDeskResult => Ok(_mapper.Map<DeskResponse>(createDeskResult)),
            errors => Problem(errors)
        );
    }
}
