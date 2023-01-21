using EMS.Data;
using EMS.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMS.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext dbContext;
        public EmployeeRepository(EmployeeDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            await dbContext.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> DeleteEmployee(Guid id)
        {
            // Finding the employee
            var emp = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            //var emp = await dbContext.Employees.FindAsync(id);
            if (emp == null)
            {
                Console.WriteLine("Inside null check");
                return null;
            }

            // Deleting the employee
            dbContext.Employees.Remove(emp);
            await dbContext.SaveChangesAsync();
            return emp;
        }
    }
}
