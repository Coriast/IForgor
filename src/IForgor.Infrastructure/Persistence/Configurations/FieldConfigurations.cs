using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate;
using IForgor.Domain.FieldAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IForgor.Infrastructure.Persistence.Configurations;
public class FieldConfigurations : IEntityTypeConfiguration<Field>
{
    public void Configure(EntityTypeBuilder<Field> builder)
    {
        ConfigureFieldsTable(builder);
    }

    private void ConfigureFieldsTable(EntityTypeBuilder<Field> builder)
    {
        builder.ToTable("Fields");

        builder.HasKey(field => field.Id);

        builder.Property(field => field.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => FieldId.Create(value));

        builder.Property(field => field.Title)
            .HasMaxLength(100);

        builder.Property(field => field.DeskId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DeskId.Create(value));
    }
}
