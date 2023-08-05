﻿using Domain.Common.Enums;
using Domain.SubjectAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("subjects");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasColumnName("Id");

        builder.Property(s => s.Name)
            .HasMaxLength(50);

        builder.HasMany(s => s.YearLevels)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

    }
}

public class YearLevelConfiguration : IEntityTypeConfiguration<YearLevel>
{
    public void Configure(EntityTypeBuilder<YearLevel> builder)
    {
        builder.ToTable("year_levels");

        builder.Property<Guid>("Id");

        builder.HasKey("Id");

        builder.Ignore(yl => yl.Name);

        builder.Property(yl => yl.YearLevelValue)
            .HasConversion(
                v => (int?)v,
                v => (YearLevelValue?)v);

        builder.Property(yl => yl.BandLevelValue)
            .HasConversion(
                v => (int?)v,
                v => (BandLevelValue?)v);

        builder.HasMany(yl => yl.Strands)
            .WithOne()
            .IsRequired()
            .HasForeignKey("YearLevelId")
            .OnDelete(DeleteBehavior.Cascade);

    }
}

public class StrandConfiguration : IEntityTypeConfiguration<Strand>
{
    public void Configure(EntityTypeBuilder<Strand> builder)
    {
        builder.ToTable("strands");

        builder.Property<Guid>("Id");

        builder.HasKey("Id");

        builder.Property(s => s.Name)
            .HasMaxLength(50);

        builder.HasMany<Substrand>()
            .WithOne()
            .HasForeignKey("StrandId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<ContentDescription>()
            .WithOne()
            .HasForeignKey("StrandId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class SubstrandConfiguration : IEntityTypeConfiguration<Substrand>
{
    public void Configure(EntityTypeBuilder<Substrand> builder)
    {
        builder.ToTable("substrands");

        builder.Property<Guid>("Id");

        builder.HasKey("Id");

        builder.Property(ss => ss.Name)
            .HasMaxLength(50);

        builder.HasMany<ContentDescription>()
            .WithOne()
            .HasForeignKey("SubstrandId")
            .OnDelete(DeleteBehavior.Cascade);

    }
}

public class ContentDescriptionConfiguration : IEntityTypeConfiguration<ContentDescription>
{
    public void Configure(EntityTypeBuilder<ContentDescription> builder)
    {
        builder.ToTable("content_descriptions");

        builder.Property<Guid>("Id");

        builder.HasKey("Id");

        builder.Property(cd => cd.Description)
            .HasMaxLength(300);

        builder.HasMany<Elaboration>()
            .WithOne()
            .HasForeignKey("ContentDescriptionId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class ElaborationConfiguration : IEntityTypeConfiguration<Elaboration>
{
    public void Configure(EntityTypeBuilder<Elaboration> builder)
    {
        builder.ToTable("elaborations");

        builder.Property<Guid>("Id");

        builder.HasKey("Id");

        builder.HasOne(typeof(ContentDescription))
            .WithMany()
            .HasForeignKey("ContentDescriptionId");

        builder.Property(e => e.Description)
            .HasMaxLength(250);
    }
}
