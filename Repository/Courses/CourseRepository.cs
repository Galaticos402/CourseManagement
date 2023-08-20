﻿using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly int itemPerPage = 10;

        public async Task<IEnumerable<Course>> GetCourseByPageNumberAndSubjectId(int page, int subjectId)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Courses.Skip(itemPerPage * (page - 1))
                                                .Take(itemPerPage)
                                                .Where(course => course.SubjectId.Equals(subjectId))
                                                .Include(course => course.Subject)
                                                .Include(course => course.Teacher)
                                                .Include (course => course.Semester)
                                                .ToListAsync();
            }
        }

        public async Task<IEnumerable<Course>> GetCoursesByPageNumber(int page)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Courses.Skip(itemPerPage * (page - 1)).Take(itemPerPage).ToListAsync();
            }
        }
    }
}
