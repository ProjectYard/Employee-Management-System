using EMS.Models.Domain;

namespace EMS.Repository
{
    public interface ITokenhandler
    {
        public Task<string> CreateTokenAsync(Employee user);
    }
}
