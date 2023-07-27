﻿using Domain.Assessments.ValueObjects;
using Domain.Common.Primatives;
using Domain.ReportAggregate.ValueObjects;
using Domain.ResourceAggregate.ValueObjects;
using Domain.StudentAggregate.ValueObjects;
using Domain.SubjectAggregates.ValueObjects;
using Domain.TeacherAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;

namespace Domain.TeacherAggregate;

public sealed class Teacher : AggregateRoot<TeacherId>
{
    private readonly List<SubjectId> _subjectIds = new();
    private readonly List<StudentId> _studentIds = new();
    private readonly List<AssessmentId> _assessmentIds = new();
    private readonly List<ResourceId> _resourceIds = new();
    private readonly List<ReportCommentId> _reportIds = new();
    public UserId UserId { get; private set; }
    public IReadOnlyList<SubjectId> SubjectIds => _subjectIds;
    public IReadOnlyList<StudentId> StudentIds => _studentIds;
    public IReadOnlyList<AssessmentId> AssessmentIds => _assessmentIds;
    public IReadOnlyList<ResourceId> ResourceIds => _resourceIds;
    public IReadOnlyList<ReportCommentId> ReportIds => _reportIds;

    private Teacher(
        TeacherId id,
        UserId userId) : base(id)
    {
        UserId = userId;
    }

    public static Teacher Create(UserId userId)
    {
        return new Teacher(TeacherId.Create(), userId);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Teacher() { }
}
