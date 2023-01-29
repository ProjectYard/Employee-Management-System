namespace EMS.Models.Domain
{
    public class User
    {
        public Employee UserEmployee { get; set; }

        public List<string> Roles { get; set; }

    }
}
