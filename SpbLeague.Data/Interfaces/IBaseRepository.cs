using SpbLeague.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpbLeague.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Create(T entity);

        IQueryable<T> GetAll();
        Task<User> GetByEmail(string email);

        Task Delete(T entity);
        Task<T> Update(T entity);
    }
}
