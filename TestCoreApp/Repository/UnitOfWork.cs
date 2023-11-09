// Implmentation of Unit Of Work Pattern

using TestCoreApp.Data;
using TestCoreApp.Models;
using TestCoreApp.Repository.Base;

namespace TestCoreApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext context ) {
            _context = context;
            categories=new MainRepository<Category>(_context);
            items=new MainRepository<Item>(_context);
            employees=new EmpRepo(_context);
        }
        private AppDbContext _context;
        public IRepository<Category> categories { get; private set; }

        public IEmpRepo employees { get; private set; }

        public IRepository<Item> items { get; private set; }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }
        //clear memory
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
