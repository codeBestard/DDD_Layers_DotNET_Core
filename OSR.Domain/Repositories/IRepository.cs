using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OSR.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
    }
}
