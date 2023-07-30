﻿using Domain.Common.Primatives;

namespace Domain.TermPlannerAggregate.ValueObjects;

public class TermPlannerIdForReference : ValueObject
{
    public Guid Value { get; private set; }

    private TermPlannerIdForReference(Guid value)
    {
        Value = value;
    }

    public static TermPlannerIdForReference Create()
    {
        return new(Guid.NewGuid());
    }

    public static TermPlannerIdForReference Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private TermPlannerIdForReference() { }

}