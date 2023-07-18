using Domain.Common.Curriculum.Entities;
using Domain.Common.Curriculum.ValueObjects;
using Domain.Common.Primatives;

namespace Domain.Common.Curriculum;

public abstract class BaseSubject : AggregateRoot<SubjectId, Guid>
{
    private readonly List<YearLevel> _yearLevels = new();
    public string Name { get; private set; }
    public IReadOnlyList<YearLevel> YearLevels => _yearLevels.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    protected BaseSubject(
        SubjectId id,
        string name,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(id)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
}