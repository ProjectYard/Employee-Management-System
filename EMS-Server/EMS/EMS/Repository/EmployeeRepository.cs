using EMS.Data;
using EMS.Models.Domain;

namespace EMS.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext dbContext;
        public EmployeeRepository(EmployeeDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return dbContext.Employees.ToList();
        }
    }
}
