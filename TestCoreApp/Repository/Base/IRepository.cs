// Creation of base generic Repository Interface 
namespace TestCoreApp.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
