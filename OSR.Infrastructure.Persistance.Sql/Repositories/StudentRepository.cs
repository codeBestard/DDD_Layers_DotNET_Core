using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSR.Domain;
using OSR.Domain.Common.Specifications.Core;
using OSR.Domain.Repositories;

namespace OSR.Infrastructure.Persistance.Sql.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly OSRDbContext _context;

        public StudentRepository(OSRDbContext context)
        {
            _context = context;
        }
        public async Task<StudentDM> GetByIdAsync(Guid id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if ( result is null )
            {
                return StudentDM.EmptyStudent;
            }
                
            return new StudentDM(result.Id, result.FirstName, result.LastName);
        }

        public async Task<List<StudentDM>> GetAllAsync()
        {
            var students = _context.Students.Select(s => new StudentDM(s.Id, s.FirstName, s.LastName));
            return await students.ToListAsync();
        }

        public Task<StudentDM> Find(ISpecification<StudentDM> spec)
        {
            throw new NotImplementedException();
        }

        public Task AddStudent(StudentDM student)
        {
            throw new NotImplementedException();
        }
    }
}