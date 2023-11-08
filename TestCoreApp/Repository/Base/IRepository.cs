// Creation of base generic Repository Interface 
using System.Linq.Expressions;

namespace TestCoreApp.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        T SelectOne(Expression<Func<T, bool>> match);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params string[] eagers);

    }
}
