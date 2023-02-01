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



        public async Task<Employee> AuthenticateAsync(string username, string password)
        {
            var user_rec = await dbContext.Employees.FirstOrDefaultAsync(x => x.Email.Equals(username) &&
            x.Password == password);

            //var user_rec = await dbContext.Users.FirstOrDefaultAsync(x => x.UserEmployee.Email.Equals(username) &&
            //x.UserEmployee.Password == password);


            if (user_rec == null)
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

        public async Task<User_Role> AddUser(Employee employee)
        {
            var rls = await dbContext.Roles.ToListAsync();

            var ur = new User_Role()
            {
                Id = Guid.NewGuid(),
                RoleId = rls.Find(x => x.Name == "reader").Id,

                UserId = employee.Id,
                //User = employee
            };
            await dbContext.Users_Roles.AddAsync(ur);
            return ur;
        }
    }
}
