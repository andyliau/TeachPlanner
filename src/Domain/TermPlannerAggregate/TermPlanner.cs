﻿using Domain.Common.Planner;
using Domain.Common.Primatives;

namespace Domain.TermPlannerAggregate;

public sealed class TermPlanner : AggregateRoot
{
    private readonly List<Guid> _weekPlannerIds = new();
    private readonly List<SchoolEvent> _schoolEvents = new();
    public int TermNumber { get; private set; }
    public DateTime TermStart { get; private set; }
    public DateTime TermEnd { get; private set; }
    public IReadOnlyList<Guid> WeekPlannerIds => _weekPlannerIds.AsReadOnly();
    public IReadOnlyList<SchoolEvent> SchoolEvents => _schoolEvents.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private TermPlanner(
        Guid id,
        List<Guid>? weekPlannerIds,
        List<SchoolEvent>? schoolEvents,
        int termNumber,
        DateTime termStart,
        DateTime termEnd,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        if (weekPlannerIds is not null)
        {
            _weekPlannerIds = weekPlannerIds;
        }

        if (schoolEvents is not null)
        {
            _schoolEvents = schoolEvents;
        }

        TermNumber = termNumber;
        TermStart = termStart;
        TermEnd = termEnd;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static TermPlanner Create(
        List<Guid> weekPlannerIds,
        List<SchoolEvent>? schoolEvents,
        int termNumber,
        DateTime termStart,
        DateTime termEnd,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new TermPlanner(
            Guid.NewGuid(),
            weekPlannerIds,
            schoolEvents,
            termNumber,
            termStart,
            termEnd,
            createdDateTime,
            updatedDateTime);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private TermPlanner() { }
}
