﻿using Microsoft.EntityFrameworkCore;
using TeachPlanner.Application.Common.Interfaces.Persistence;
using TeachPlanner.Domain.Subjects;
using TeachPlanner.Infrastructure.Persistence.DbContexts;

namespace TeachPlanner.Infrastructure.Persistence.Repositories;
public class CurriculumRepository : ICurriculumRepository
{
    private readonly ApplicationDbContext _context;

    public CurriculumRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<Subject>> GetSubjects(bool elaborations, List<Guid>? subjectsTaught = null)
    {
        IQueryable<Subject> query;
        IQueryable<Subject> mathsQuery;

        if (elaborations == true)
        {
            query = _context.Subjects
                .Include(s => s.YearLevels)
                .ThenInclude(yl => yl.Strands)
                .ThenInclude(s => s.Substrands!)
                .ThenInclude(s => s.ContentDescriptions)
                .ThenInclude(cd => cd.Elaborations)
                .Where(s => s.Name != "Mathematics");


            mathsQuery = _context.Subjects
                .Include(s => s.YearLevels)
                .ThenInclude(yl => yl.Strands)
                .ThenInclude(s => s.ContentDescriptions!)
                .ThenInclude(cd => cd.Elaborations)
                .Where(s => s.Name == "Mathematics");
        }
        else
        {
            query = _context.Subjects
                .Include(s => s.YearLevels)
                .ThenInclude(yl => yl.Strands)
                .ThenInclude(s => s.Substrands!)
                .ThenInclude(s => s.ContentDescriptions)
                .Where(s => s.Name != "Mathematics");


            mathsQuery = _context.Subjects
                .Include(s => s.YearLevels)
                .ThenInclude(yl => yl.Strands)
                .ThenInclude(s => s.ContentDescriptions!)
                .Where(s => s.Name == "Mathematics");
        }

        if (subjectsTaught != null && subjectsTaught.Count > 0)
        {
            query = query.Where(s => subjectsTaught.Contains(s.Id));
            mathsQuery = mathsQuery.Where(s => subjectsTaught.Contains(s.Id));
        }

        var subjects = query.ToList();
        var maths = mathsQuery.SingleOrDefault();

        if (maths != null)
        {
            subjects.Add(maths);
        }

        return Task.FromResult(subjects);

    }

    public Task SaveCurriculum(List<Subject> subjects)
    {
        // clear existing subjects
        _context.Subjects.RemoveRange(_context.Subjects);
        _context.SaveChanges();
        // add new subjects
        foreach (var subject in subjects)
        {
            _context.Subjects.Add(subject);
        }

        return _context.SaveChangesAsync();
    }
}
