﻿using Application.Common.Interfaces.Persistence;
using Domain.LessonPlanAggregate;
using ErrorOr;
using MediatR;
using Application.Common.Errors;

namespace Application.LessonPlans.Queries.GetLessonPlans;
public class GetLessonPlansQueryHandler : IRequestHandler<GetLessonPlansQuery, ErrorOr<List<LessonPlan>>>
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly ILessonRepository _lessonRepository;

    public GetLessonPlansQueryHandler(ITeacherRepository teacherRepository, ILessonRepository lessonRepository)
    {
        _teacherRepository = teacherRepository;
        _lessonRepository = lessonRepository;
    }

    public async Task<ErrorOr<List<LessonPlan>?>> Handle(GetLessonPlansQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetTeacherByIdAsync(request.TeacherId);

        if (teacher is null)
        {
            return Errors.Teacher.TeacherNotFound;
        }

        var lessonPlans = await _lessonRepository.GetLessonsByTeacherIdAsync(request.TeacherId);

        return lessonPlans;
    }
}
