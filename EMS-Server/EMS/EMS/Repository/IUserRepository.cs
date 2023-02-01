using EMS.Models.Domain;

namespace EMS.Repository
{
    public interface IUserRepository
    {
        Task<Employee> AuthenticateAsync(string username, string password);

        Task<User_Role> AddUser(Employee employee);
    }
}
