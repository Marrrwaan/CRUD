using CRUD_APIs.DataAccess;
using CRUD_APIs.Entities;

namespace CRUD_APIs.DataService
{
    public class EmployeesDSL
    {
        private readonly EmployeesDAL _employeesDAL;
        public EmployeesDSL(EmployeesDAL employeesDAL)
        {
            _employeesDAL= employeesDAL;
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            return await _employeesDAL.GetEmployees();
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            return await _employeesDAL.GetEmployeeById(id);
        }

        public async Task AddEmployee(EmployeeDTO newEmployee)
        {
            await _employeesDAL.AddEmployee(newEmployee);
        }

        public async Task UpdateEmployee(EmployeeDTO updatedEmployee)
        {
            await _employeesDAL.UpdateEmployee(updatedEmployee);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await _employeesDAL.DeleteEmployee(employeeId);
        }
    }
}
