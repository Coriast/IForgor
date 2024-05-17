using ErrorOr;
using IForgor.Application.Common.Interfaces.Persistence;
using IForgor.Domain.DeskAggregate;
using IForgor.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace IForgor.Application.Desks.Commands.CreateDesk;

public class CreateDeskCommandHandler : IRequestHandler<CreateDeskCommand, ErrorOr<Desk>>
{
    private readonly IDeskRepository _deskRepository;

    public CreateDeskCommandHandler(IDeskRepository deskRepository)
    {
        _deskRepository = deskRepository;
    }

    public async Task<ErrorOr<Desk>> Handle(CreateDeskCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create a Desk
        var desk = Desk.Create(request.Title, UserId.Create(request.UserId));

        // Persist Desk
        _deskRepository.Add(desk);

        // Return Desk
        return desk;
    }
}
