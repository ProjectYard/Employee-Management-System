using EMS.Models.Domain;

namespace EMS.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployee();

        Task<Employee> GetEmployeeById(Guid id);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> DeleteEmployee(Guid id);

        Task<Employee> UpdateEmployee(Guid id, Employee employee);
    }
}
