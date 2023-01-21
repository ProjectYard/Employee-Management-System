﻿using AutoMapper;
using EMS.Models.DTO;
using EMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepository _employeeRepository, IMapper _mapper)
        {
            employeeRepository = _employeeRepository;
            mapper = _mapper;
        }

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
    }
}
