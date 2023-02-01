using EMS.Data;
using EMS.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMS.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeDbContext dbContext;
        public UserRepository(EmployeeDbContext _dbContext)
        {
            dbContext = _dbContext;
        }



        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user_rec = await dbContext.Users.FirstOrDefaultAsync(x => x.UserEmployee.Email.Equals(username) &&
            x.UserEmployee.Password == password);

            //var user_rec = await dbContext.Users.FirstOrDefaultAsync(x => x.UserEmployee.Email.Equals(username) &&
            //x.UserEmployee.Password == password);

            var a = await dbContext.Users.FindAsync(user_rec.Id);



            if (user_rec.UserEmployee == null)
            {
                Console.WriteLine("***** EMPLOYEE IS EMPTY *****");
                return null;
            }

            var userRoles = await dbContext.Users_Roles.Where(x => x.UserId == user_rec.Id).ToListAsync();

            if (userRoles.Any())
            {
                user_rec.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await dbContext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user_rec.Roles.Add(role.Name);
                    }
                }
            }

            //user_rec.UserEmployee.Password = null;
            Console.WriteLine(user_rec);
            return user_rec;
        }
    }
}
