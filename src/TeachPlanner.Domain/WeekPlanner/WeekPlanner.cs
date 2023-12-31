﻿using TeachPlanner.Domain.Common.Planner;
using TeachPlanner.Domain.Common.Primatives;
using TeachPlanner.Domain.LessonPlans;

namespace TeachPlanner.Domain.WeekPlanners;

public sealed class WeekPlanner : AggregateRoot
{
    private readonly List<LessonPlan> _lessonPlans = new();
    private readonly List<SchoolEvent> _schoolEvents = new();
    public DateTime WeekStart { get; private set; }
    public int WeekNumber { get; private set; }
    public IReadOnlyList<LessonPlan> LessonPlans => _lessonPlans.AsReadOnly();
    public IReadOnlyList<SchoolEvent> SchoolEvents => _schoolEvents.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private WeekPlanner(
        Guid id,
        DateTime weekStart,
        List<LessonPlan> lessonPlans,
        List<SchoolEvent>? schoolEvents) : base(id)
    {
        WeekStart = weekStart;
        _lessonPlans = lessonPlans;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;

        if (schoolEvents is not null)
        {
            _schoolEvents = schoolEvents;
        }
    }

    public static WeekPlanner Create(
        DateTime weekStart,
        List<LessonPlan> lessonPlans,
        List<SchoolEvent>? schoolEvents = null)
    {
        return new WeekPlanner(
            Guid.NewGuid(),
            weekStart,
            lessonPlans,
            schoolEvents);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private WeekPlanner() { }
}
