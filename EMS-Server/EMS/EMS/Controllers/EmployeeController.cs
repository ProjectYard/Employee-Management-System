using EMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var emp = employeeRepository.GetAllEmployee();
            if (emp == null)
            {
                return NotFound();
            }

            // return DTOs
            var employeesDTO = new List<Models.DTO.Employee>();
            emp.ToList().ForEach(x =>
            {
                var empDTO = new Models.DTO.Employee()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    Email = x.Email,
                    Salary = x.Salary,
                    Location = x.Location,
                    Department = x.Department,
                    Password = x.Password,
                };
            });

            return Ok(employeesDTO);
        }
    }
}
