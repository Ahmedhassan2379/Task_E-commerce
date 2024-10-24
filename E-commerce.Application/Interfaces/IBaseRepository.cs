using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string? includes = null);
        Task<T> GetById(Expression<Func<T,bool>> match,string? includes = null);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? match, string? includes = null);
        Task<IEnumerable<T>> FindPagination(int take, int skipe ,string? includes = null);
    }
}
