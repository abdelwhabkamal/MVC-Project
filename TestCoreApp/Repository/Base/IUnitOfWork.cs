// Creation of base Unit Of Work Pattern Interface 

using Elfie.Serialization;
using TestCoreApp.Models;

namespace TestCoreApp.Repository.Base
{
  //IDisposable helps prevent resource leaks and ensures efficient resource management
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> categories {  get; }
        IRepository<Employee> employees { get; }
        IRepository<Item> items { get; }
        int CommitChanges();
    }
}
