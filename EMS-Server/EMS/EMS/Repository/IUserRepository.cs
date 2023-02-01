using EMS.Models.Domain;

namespace EMS.Repository
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);

        //Task<User> AddUser(Employee employee);
    }
}
