using IForgor.Domain.DeskAggregate;
using IForgor.Domain.DeskAggregate.ValueObjects;
using IForgor.Domain.FieldAggregate;
using IForgor.Domain.ProjectAggregate;
using IForgor.Domain.StudySubjectAggregate;
using IForgor.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IForgor.Infrastructure.Persistence.Configurations;
public class DeskConfigurations : IEntityTypeConfiguration<Desk>
{
    public void Configure(EntityTypeBuilder<Desk> builder)
    {
        ConfigureDesksTable(builder);
        ConfigureDeskProjectIdsTable(builder);
        ConfigureStudySubjectIdsTable(builder);
        ConfigureFieldIdsTable(builder);
    }

    private void ConfigureFieldIdsTable(EntityTypeBuilder<Desk> builder)
    {
        builder.OwnsMany(desk => desk.FieldIds, fb =>
        {
            fb.ToTable("DeskFieldIds");

            fb.WithOwner().HasForeignKey("DeskId");

            fb.HasKey("Id");

            fb.Property(field => field.Value)
                .ValueGeneratedNever()
                .HasColumnName("FieldId");
        });

        builder.Metadata.FindNavigation(nameof(Desk.FieldIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureStudySubjectIdsTable(EntityTypeBuilder<Desk> builder)
    {
        builder.OwnsMany(desk => desk.StudySubjectIds, sb =>
        {
            sb.ToTable("DeskStudySubjectsIds");

            sb.WithOwner().HasForeignKey("DeskId");

            sb.HasKey("Id");

            sb.Property(studySubject => studySubject.Value)
                .ValueGeneratedNever()
                .HasColumnName("StudySubjectId");
        });

        builder.Metadata.FindNavigation(nameof(Desk.StudySubjectIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureDeskProjectIdsTable(EntityTypeBuilder<Desk> builder)
    {
        builder.OwnsMany(desk => desk.ProjectIds, pb => {
            pb.ToTable("DeskProjectIds");

            pb.WithOwner().HasForeignKey("DeskId");

            pb.HasKey("Id");

            pb.Property(project => project.Value)
                .ValueGeneratedNever()
                .HasColumnName("ProjectId");
        });

        builder.Metadata.FindNavigation(nameof(Desk.ProjectIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureDesksTable(EntityTypeBuilder<Desk> builder)
    {
        builder.ToTable("Desks");

        builder.HasKey(desk => desk.Id);

        // Conversion INTO the database
        // and OUT of the database
        builder.Property(desk => desk.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DeskId.Create(value));

        builder.Property(desk => desk.Title)
            .HasMaxLength(100);

        builder.Property(desk => desk.UserId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value.ToString()));
    }
}
