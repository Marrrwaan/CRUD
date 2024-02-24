using CRUD_APIs.DataService;
using CRUD_APIs.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_APIs.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly EmployeesDSL _employeeDSL;
        public EmployeesController(EmployeesDSL employeeDSL)
        {
            _employeeDSL = employeeDSL;
        }

        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _employeeDSL.GetEmployees());
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await _employeeDSL.GetEmployeeById(id));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeDTO newEmployee)
        {
            await _employeeDSL.AddEmployee(newEmployee);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO updatedEmployee)
        {
            await _employeeDSL.UpdateEmployee(updatedEmployee);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeDSL.DeleteEmployee(id);
            return Ok();
        }
    }
}
