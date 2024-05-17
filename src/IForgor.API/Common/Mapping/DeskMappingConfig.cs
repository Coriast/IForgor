using IForgor.Application.Desks.Commands.CreateDesk;
using IForgor.Contracts.Desks;
using IForgor.Domain.DeskAggregate;
using Mapster;

namespace IForgor.API.Common.Mapping;

public class DeskMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateDeskRequest Request, string UserId), CreateDeskCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Desk, DeskResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.ProjectIds, src => src.ProjectIds.Select(projectId => projectId.Value))
            .Map(dest => dest.ProjectIds, src => src.StudySubjectIds.Select(studySubjectId => studySubjectId.Value))
            .Map(dest => dest.ProjectIds, src => src.FieldIds.Select(fieldId => fieldId.Value));

    }
}
