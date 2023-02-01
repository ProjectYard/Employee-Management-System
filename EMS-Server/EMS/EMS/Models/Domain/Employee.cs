using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Salary { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [NotMapped]
        public List<string> Roles { get; set; }

        public List<User_Role> UserRoles { get; set; }
    }
}
