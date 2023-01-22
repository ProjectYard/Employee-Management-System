using AutoMapper;
using EMS.Models.DTO;
using EMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    /* DECORATOR FOR CONTROLLER */
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        /* DEPENDENCY INJECTION OF REPOSITORY */
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepository _employeeRepository, IMapper _mapper)
        {
            employeeRepository = _employeeRepository;
            mapper = _mapper;
        }

        /* ------------- GET METHODS ------------- */

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var emp = await employeeRepository.GetAllEmployee();
            if (emp == null)
            {
                return NotFound();
            }

            // return DTOs
            var employeesDTO = mapper.Map<List<Models.DTO.Employee>>(emp);

            return Ok(employeesDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var emp = await employeeRepository.GetEmployeeById(id);

            if (emp == null)
            {
                return NotFound();
            }

            var empDTO = mapper.Map<Models.DTO.Employee>(emp);
            return Ok(emp);
        }

        /* ------------- POST METHODS ------------- */

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployee addEmployee)
        {
            // Request(DTO) to domain model
            var emp = new Models.Domain.Employee()
            {
                FirstName = addEmployee.FirstName,
                LastName = addEmployee.LastName,
                Email = addEmployee.Email,
                Phone = addEmployee.Phone,
                Salary = addEmployee.Salary,
                Location = addEmployee.Location,
                Department = addEmployee.Department,
                Password = addEmployee.Password,
            };

            // Pass details to repository
            var empRTT = await employeeRepository.AddEmployee(emp);
            if (empRTT == null)
            {
                return BadRequest();
            }

            // Convert the Domain to DTO again
            var empDTO = new Models.DTO.Employee()
            {
                Id = empRTT.Id,
                FirstName = empRTT.FirstName,
                LastName = empRTT.LastName,
                Email = empRTT.Email,
                Phone = empRTT.Phone,
                Salary = empRTT.Salary,
                Location = empRTT.Location,
                Department = empRTT.Department,
                Password = empRTT.Password,
            };

            //return CreatedAtAction(nameof(GetEmployeeById), new { id = empDTO.Id }, empDTO);
            return Ok(empDTO);
        }

        /* ------------- DELETE METHODS ------------- */

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            // Get employee form DB
            var deletedEmp = await employeeRepository.DeleteEmployee(id);

            // Check for null
            if (deletedEmp == null)
            {
                return NotFound();
            }

            // Convert domain to DTO
            var empDTO = new Models.DTO.Employee()
            {
                Id = deletedEmp.Id,
                FirstName = deletedEmp.FirstName,
                LastName = deletedEmp.LastName,
                Email = deletedEmp.Email,
                Phone = deletedEmp.Phone,
                Salary = deletedEmp.Salary,
                Location = deletedEmp.Location,
                Department = deletedEmp.Department,
                Password = deletedEmp.Password,
            };

            // return ok response
            return Ok(empDTO);
        }

        /* ------------- PUT METHODS ------------- */

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] Models.DTO.UpdateEmployee updateEmp)
        {
            // Convrt DTO to domain model
            var emp = new Models.Domain.Employee()
            {
                FirstName = updateEmp.FirstName,
                LastName = updateEmp.LastName,
                Email = updateEmp.Email,
                Phone = updateEmp.Phone,
                Salary = updateEmp.Salary,
                Location = updateEmp.Location,
                Department = updateEmp.Department,
                Password = updateEmp.Password,
            };

            // update employee using repo
            emp = await employeeRepository.UpdateEmployee(id, emp);

            // if null return 
            if (emp == null)
            {
                return NotFound();
            }

            // convert domain back to dto
            var empDTO = new Models.DTO.Employee()
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                Phone = emp.Phone,
                Salary = emp.Salary,
                Location = emp.Location,
                Department = emp.Department,
                Password = emp.Password,
            };

            // return ok response
            return Ok(empDTO);
        }
    }
}
