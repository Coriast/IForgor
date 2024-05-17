# Domain Models

## Desk

```csharp
class Desk
{
    Desk Create();

    void AddProject(Project project);
    void AddStudySubject(StudySubject studySubject);
    void AddField(Field field);

    void RemoveProject(Project project);
    void RemoveStudySubject(StudySubject studySubject);
    void RemoveField(Field field);

    void UpdateMilestone(Milestone milestone);
    void UpdateField(Field field);
}
```

```json
{
    "id": "00000-000000-00000-0000",
    "title": "My Mind",
    "projectIds": [
        "00000-000000-00000-0000",
    ],
    "studySubjectIds": [
        "00000-000000-00000-0000",
    ],
    "fieldIds": [
        "00000-000000-00000-0000", 
    ],
    "milestoneId": "00000-000000-00000-0000",
    "createdDateTime": "2024-01-01"
}
```

## User

```csharp
class User
{
    User Create();

    void AddDesk(Desk desk);

    void RemoveDesk(Desk desk);
}
```

```json
{
    "id": "00000-000000-00000-0000",
    "nickname": "Coriast",
    "email": "coriast@gmail.com",
    "password": "1234",
    "deskIds": [
        "00000-000000-00000-0000",
    ]
}
```

## Project

```csharp
class Project
{
    Project Create();

    void AddField(Field field);
    void RemoveField(Field field);

    void UpdateMilestone(Milestone milestone);
}
```

```json
{
    "id": "00000-000000-00000-0000",
    "title": "Debol",
    "description": "Um compilador da linguagem Debol, baseado no tiny BASIC, para 
	ser programado em C++ e também Go. (.gt) /https://compilerbook.com/",
    "status": "new",
    "milestoneId": "00000-000000-00000-0000",
    "fieldId": "00000-000000-00000-0000",
    "deskId": "00000-000000-00000-0000",
    "createdDateTime": "2024-01-01"
}
```

## Study Subject

```csharp
class StudySubject
{
    StudySubject Create();

    void AddStudyMaterial(StudySubjectMaterial studySubjectMaterial);
    void AddField(Field field);

    void RemoveStudyMaterial(StudySubjectMaterial studySubjectMaterial);
    void RemoveField(Field field);

    void UpdateStudyMaterial(StudySubjectMaterial studySubjectMaterial);
    void UpdateMilestone(Milestone milestone);
}
```

```json
{
    "id": "00000-000000-00000-0000",
    "title": "Unity",
    "materials": [
        {
            "id": "00000-000000-00000-0000",
            "name": "The Unity Shaders Bible",
            "sources": [
                "link do livro",
            ]
        },
    ],
    "fieldId": "00000-000000-00000-0000",
    "milestoneId": "00000-000000-00000-0000",
    "deskId": "00000-000000-00000-0000",
    "createdDateTime": "2024-01-01"
}
```

## Field

```csharp
class Field
{
    Field Create();
}
```

```json
{
    "id": "00000-000000-00000-0000",
    "title": "Game Development",
    "deskId": "00000-000000-00000-0000",
    "createdDateTime": "2024-01-01"
}
```