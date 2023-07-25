﻿using Domain.Common.Enums;
using Domain.Common.Primatives;
using Domain.YearPlannerAggregate.Entities;
using Domain.YearPlannerAggregate.ValueObjects;

namespace Domain.YearPlannerAggregate;
public class YearPlanner : AggregateRoot<YearPlannerId>
{
    private readonly List<TermPlan> _termPlans = new();
    public YearLevelValue YearLevel { get; private set; }
    public IReadOnlyList<TermPlan> TermPlans => _termPlans.AsReadOnly();

    private YearPlanner(YearPlannerId id, YearLevelValue yearLevel, List<TermPlan> termPlans) : base(id)
    {
        YearLevel = yearLevel;
        _termPlans = termPlans;
    }

    public static YearPlanner Create(YearLevelValue yearLevel, List<TermPlan> termPlans)
    {
        return new YearPlanner(
            new YearPlannerId(Guid.NewGuid()),
            yearLevel,
            termPlans);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private YearPlanner() { }
}