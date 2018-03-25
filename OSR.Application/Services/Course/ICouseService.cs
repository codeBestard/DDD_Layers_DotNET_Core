using System;
using System.Threading.Tasks;
using OSR.Application.ReadModels;

namespace OSR.Application.Services.Course
{
    public interface ICouseService
    {
        Task<CourseRM> GetByIdAsync( Guid courseId );
        Task<CourseRM> AddStudentToCourseAsync( Guid courseId , Guid studentId );
        Task RemoveStudentFromCourseAsync( Guid courseId , Guid studentId );
    }
}