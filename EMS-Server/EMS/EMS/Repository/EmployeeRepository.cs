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

                return null;
            }

            // Deleting the employee
            dbContext.Employees.Remove(emp);
            await dbContext.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> UpdateEmployee(Guid id, Employee employee)
        {
            // Getting existing employee
            var prevEmp = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            // checking for null
            if (prevEmp == null)
            {
                return null;
            }

            // Changing values in previous data with the new ones
            //if (employee.FirstName != "")
            //    prevEmp.FirstName = employee.FirstName;

            //if (employee.LastName != "")
            //    prevEmp.LastName = employee.LastName;

            //if (employee.Email != "")
            //    prevEmp.Email = employee.Email;

            //if (employee.Phone != "")
            //    prevEmp.Phone = employee.Phone;

            //if (employee.Salary != 0)
            //    prevEmp.Salary = employee.Salary;

            //if (employee.Department != "")
            //    prevEmp.Department = employee.Department;

            //if (employee.Password != "")
            //    prevEmp.Password = employee.Password;

            //if (employee.Location != "")
            //    prevEmp.Location = employee.Location;

            prevEmp.FirstName = employee.FirstName;
            prevEmp.LastName = employee.LastName;
            prevEmp.Email = employee.Email;
            prevEmp.Phone = employee.Phone;
            prevEmp.Salary = employee.Salary;
            prevEmp.Department = employee.Department;
            prevEmp.Password = employee.Password;
            prevEmp.Location = employee.Location;

            await dbContext.SaveChangesAsync();

            return prevEmp;
        }
    }
}
