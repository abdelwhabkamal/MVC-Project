// Creation of Main Repository class
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestCoreApp.Data;
using TestCoreApp.Repository.Base;

namespace TestCoreApp.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        private AppDbContext _context;
        public MainRepository(AppDbContext context) {
            this._context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        //add eager loading to optimize the retrieval of related data

        public async Task<IEnumerable<T>> GetAllAsync(params string[] eagers)
        {
            IQueryable<T> query = _context.Set<T>();
            if(eagers.Length > 0)
            {
                foreach(string eager in eagers)
                {
                    query=query.Include(eager);
                }
            }
            return await query.ToListAsync();
        }
    }
}
