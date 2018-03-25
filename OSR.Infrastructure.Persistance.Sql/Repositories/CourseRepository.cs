using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSR.Domain;
using OSR.Domain.Common.Specifications.Core;
using OSR.Domain.Common.ValueObjects;
using OSR.Domain.Repositories;
using OSR.Infrastructure.Persistance.Sql.Entities;

namespace OSR.Infrastructure.Persistance.Sql.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly OSRDbContext _context;

        public CourseRepository(OSRDbContext context)
        {
            _context = context;
        }

        public async Task<CourseDM> GetByIdAsync(Guid courseId)
        {
            var course     = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

            var students   = _context.CourseEnrollments
                .Where(ce => ce.CourseId == courseId)
                .Select(ce => ce.Student);

            var instructor = _context.CourseAssignments
                .Where(ca => ca.CourseId == courseId)
                .Select(ca => ca.Instructor).First();

            var courseDM   = new CourseDM(
                id           : courseId,
                title        : course.Title,
                dateTimeRange: new DateTimeRange(course.StartDateTime, course.EndDateTime),
                maxCapacity  : new Capacity( course.MaxCapacity ),
                instructorId : instructor.Id,
                students     : students.Select(s => new StudentDM(s.Id, s.FirstName, s.LastName))
                );

            return courseDM;
        }

        public Task<CourseDM> Find(ISpecification<CourseDM> spec)
        {
            throw new NotImplementedException();
        }

        public Task AddCourse(CourseDM course)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseDM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CourseDM> AddStudentToCourseAsync(Guid courseId, Guid studentId)
        {
            var courseEnrollment = new CourseEnrollment
            {
                CourseId  = courseId,
                StudentId = studentId,
            };
            await _context.AddAsync(courseEnrollment);

            return await GetByIdAsync(courseId);
        }

        public async Task RemoveStudentFromCourseAsync(Guid courseId, Guid studentId)
        {
            var courseEnrollement = await _context.CourseEnrollments
                                            .FirstOrDefaultAsync(ce => ce.CourseId == courseId && ce.StudentId == studentId);

            if ( ! (courseEnrollement is null) )
            {
                _context.Remove( courseEnrollement );
            }
        }
    }
}
