using EMS.Models.Domain;

namespace EMS.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
    }
}
