namespace IForgor.Contracts.StudySubjects;
public record CreateStudySubjectRequest(string Title, List<StudySubjectMaterial> Materials);

public record StudySubjectMaterial(string Name, List<string> Sources);