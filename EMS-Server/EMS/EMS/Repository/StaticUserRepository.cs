using EMS.Models.Domain;

namespace EMS.Repository
{
    public class StaticUserRepository : IUserRepository
    {

        private List<User> Users = new List<User>()
        {
            new User()
            {
                UserEmployee = new Employee()
                {
                    FirstName= "Ashish",LastName="Sahu", Email="ashishsahu10428@gmail.com",
                    Id = Guid.NewGuid(), Password = "@Happy2015",
                },
                Roles = new List<string> {"reader","writer"}
            },
            new User()
            {
                UserEmployee = new Employee()
                {
                    FirstName= "Shristi",LastName="Jalan", Email="shristijalan1010@gmail.com",
                    Id = Guid.NewGuid(), Password = "@Smile2015",
                },
                Roles = new List<string> {"reader"}
            },

        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.UserEmployee.Email.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
            x.UserEmployee.Password == password);

            return user;
        }
    }
}
