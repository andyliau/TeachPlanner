﻿using Domain.Common.Curriculum.ValueObjects;
using Domain.Common.Primatives;
using Domain.LessonPlanAggregate.ValueObjects;
using Domain.Resource.ValueObjects;

namespace Domain.Resource;

public sealed class Resource : AggregateRoot<ResourceId>
{
    private readonly List<LessonPlanId> _lessonIds = new();
    public string Name { get; private set; }
    public string Url { get; private set; }
    public bool IsAssessment { get; private set; }
    public IReadOnlyList<LessonPlanId> Lessons => _lessonIds.AsReadOnly();
    public SubjectId SubjectId { get; private set; }
    public StrandId? StrandId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Resource(
        string name,
        string url,
        bool isAssessment,
        SubjectId subjectId,
        StrandId? strandId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        Name = name;
        Url = url;
        IsAssessment = isAssessment;
        SubjectId = subjectId;
        StrandId = strandId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Resource Create(
        string name,
        string url,
        bool isAssessment,
        SubjectId subjectId,
        StrandId? strandId)
    {
        return new(name, url, isAssessment, subjectId, strandId, DateTime.UtcNow, DateTime.UtcNow);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Resource() { }

}