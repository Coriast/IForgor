namespace IForgor.Contracts.Desks;
public record DeskResponse(
    string Id,
    string Title,
    string UserId,
    List<string> ProjectIds,
    List<string> StudySubjectIds,
    List<string> FieldIds);
