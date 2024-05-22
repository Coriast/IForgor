using IForgor.Domain.Common.Models;
using IForgor.Domain.StudySubjectAggregate.ValueObjects;

namespace IForgor.Domain.StudySubjectAggregate.Entities;
public sealed class StudySubjectMaterial : Entity<StudySubjectMaterialId>
{
    public string Name { get; }
    public List<string> Sources { get; } = new List<string>();

    private StudySubjectMaterial(StudySubjectMaterialId id, string name, List<string> sources) : base(id)
    {
        Name = name;
        Sources = sources;
    }

#pragma warning disable CS8618
    private StudySubjectMaterial()
    {
    }
#pragma warning restore CS8618

    public static StudySubjectMaterial Create(string name, List<string> sources)
    {
        return new(StudySubjectMaterialId.CreateUnique(), name, sources);
    }
}
