using E_commerce.Application.Interfaces;
using E_commerce.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastracture.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _Context;
        public BaseRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        public async Task<IEnumerable<T>> GetAll(string include)
        {
            if(include != null)
            {
                var result = await _Context.Set<T>().Include(include).AsNoTracking().ToListAsync();
                return result;
            }
            else
            {
                var result = await _Context.Set<T>().AsNoTracking().ToListAsync();
                return result;
            }
        }

        public async Task<T> GetById(Expression<Func<T,bool>> match, string include)
        {
            IQueryable<T> query =  _Context.Set<T>();
            if (include != null)
                query = query.Include(include);
            return await query.FirstOrDefaultAsync(match);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T,bool>>? match, string include = null)
        {
            IQueryable<T> query = _Context.Set<T>();
            if (match != null)
            {
                if (include != null)
                    query = query.Include(include);
                return await query.Where(match).ToListAsync();
            }
            else
            {
                if (include != null)
                    query = query.Include(include);
                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<T>> FindPagination( int page, int pageSize, string include = null)
        {
            var  skipe = pageSize * (page - 1);
            var take = pageSize;
            IQueryable<T> query = _Context.Set<T>();
            if (include != null)
                query = query.Include(include);
            var finalProducts = await query.Skip(skipe).Take(take).ToListAsync();
            return finalProducts;

        }
    }
}
