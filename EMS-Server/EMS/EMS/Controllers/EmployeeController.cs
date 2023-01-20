using EMS.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var Emp = new List<Employee>()
            {
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName= "Ashish",
                    LastName= "Sahu",
                    Phone = "8210209272",
                    Email = "ashish@gmail.com",
                    Salary = 50000,
                    Location = "Jamshedpur",
                    Password= "password",

                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName= "Ash",
                    LastName= "Prime",
                    Phone = "8210209273",
                    Email = "ashish2@gmail.com",
                    Salary = 40000,
                    Location = "Jamshedpur",
                    Password= "password1",

                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName= "Ashly",
                    LastName= "Sahu",
                    Phone = "8210209562",
                    Email = "ashish34@gmail.com",
                    Salary = 60000,
                    Location = "Jamshedpur",
                    Password= "password2",

                },
            };
            return Ok(Emp);
        }
    }
}
