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

    public static StudySubjectMaterial Create(string name, List<string> sources)
    {
        return new(StudySubjectMaterialId.CreateUnique(), name, sources);
    }
}
