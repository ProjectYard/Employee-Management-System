namespace EMS.Models.DTO
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }
    }
}
