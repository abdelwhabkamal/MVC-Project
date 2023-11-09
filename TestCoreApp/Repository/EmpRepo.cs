using TestCoreApp.Data;
using TestCoreApp.Migrations;
using TestCoreApp.Repository.Base;

namespace TestCoreApp.Repository
{
    public class EmpRepo : MainRepository<Employee>, IEmpRepo
    {
        public EmpRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        private AppDbContext _context;
        public decimal getSalary(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void setPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
