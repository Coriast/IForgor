using IForgor.Application.Fields.Commands.CreateField;
using IForgor.Contracts.Fields;
using IForgor.Domain.FieldAggregate;
using Mapster;

namespace IForgor.API.Common.Mapping;

public class FieldMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateFieldRequest Request, string DeskId), CreateFieldCommand>()
            .Map(dest => dest.DeskId, src => src.DeskId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Field, FieldResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.DeskId, src => src.DeskId.Value);
    }
}
