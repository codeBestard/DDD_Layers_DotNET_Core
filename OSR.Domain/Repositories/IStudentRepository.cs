using System.Threading.Tasks;
using OSR.Domain.Common.Specifications.Core;

namespace OSR.Domain.Repositories
{
    public interface IStudentRepository : IRepository<StudentDM>
    {
        Task<StudentDM> Find( ISpecification<StudentDM> spec );

        Task AddStudent( StudentDM student );

    }
}