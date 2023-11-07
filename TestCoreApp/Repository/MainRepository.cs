// Creation of Main Repository class
using TestCoreApp.Data;
using TestCoreApp.Repository.Base;

namespace TestCoreApp.Repository
{
    public class MainRepository<T>:IRepository<T> where T : class
    {
        private AppDbContext _context;
        public MainRepository(AppDbContext context) {
            this._context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
