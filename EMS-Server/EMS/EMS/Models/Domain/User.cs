using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public Employee UserEmployee { get; set; }
        [NotMapped]
        public List<string> Roles { get; set; }


        public List<User_Role> UserRoles { get; set; }

    }
}
