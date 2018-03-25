using System;
using System.Linq;
using System.Threading.Tasks;
using OSR.Application.ReadModels;
using OSR.Domain;
using OSR.Domain.Repositories;
using OSR.Infrastructure.Persistance.Sql;

namespace OSR.Application.Services.Course
{
    public class CourseService : ICouseService
    {
        private readonly OSRDbContext _context;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;


        public CourseService(
            OSRDbContext context,
            ICourseRepository courseRepository,
            IStudentRepository studentRepository)
        {
            _context = context;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        public async Task<CourseRM> GetByIdAsync(Guid courseId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            var courseRM = MapCourseRM(course);

            return courseRM;
        }



        public async Task<CourseRM> AddStudentToCourseAsync(Guid courseId, Guid studentId)
        {
            var course = await _courseRepository.GetByIdAsync( courseId );

            var student = await _studentRepository.GetByIdAsync(studentId);

            course.AddStudent(student);

            await _courseRepository.AddStudentToCourseAsync(courseId, studentId);

            await _context.SaveChangesWithNoticationsAsync(course);

            return MapCourseRM(course);
        }

        public async Task RemoveStudentFromCourseAsync(Guid courseId, Guid studentId)
        {
            await _courseRepository.RemoveStudentFromCourseAsync(courseId, studentId);

            await _context.SaveChangesAsync( );
        }

        private static CourseRM MapCourseRM( CourseDM course )
        {
            if ( course is null )
            {
                throw new ArgumentNullException(nameof(course));
            }

            var courseRM = new CourseRM
            {
                CourseId = course.Id ,
                Title = course.Title ,
                StarttDateTime = course.DateTimeRange.Start ,
                EndDateTime = course.DateTimeRange.End ,
                MaxCapacity = course.MaxCapacity.MaxOccupant ,
                Students = course.Students.Select( s =>
                    new StudentRM
                    {
                        StudentId = s.Id ,
                        FirstName = s.FirstName ,
                        LastName = s.LastName ,
                    } )
            };
            return courseRM;
        }
    }
}
