using System;
using System.Threading.Tasks;
using OSR.Domain.Common.Specifications.Core;

namespace OSR.Domain.Repositories
{
    public interface ICourseRepository : IRepository<CourseDM>
    {
        Task<CourseDM> Find(ISpecification<CourseDM> spec);

        Task AddCourse(CourseDM course);

        Task<CourseDM> AddStudentToCourseAsync(Guid courseId, Guid studentId);

        Task RemoveStudentFromCourseAsync(Guid courseId, Guid studentId);
    }
}
