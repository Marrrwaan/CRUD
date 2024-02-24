using CRUD_APIs.Entities;
using CRUD_APIs.Helpers;
using System.Data.SqlClient;

namespace CRUD_APIs.DataAccess
{
    public class EmployeesDAL
    {
        private readonly ConfigurationHelper _configureManager;
        public EmployeesDAL(ConfigurationHelper configureManager)
        {
            _configureManager = configureManager;
        }
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            using (SqlConnection conn = new SqlConnection(_configureManager.ConnectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Employees", conn))
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        employees.Add(new EmployeeDTO
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Address = reader.GetString(4),
                            Salary = reader.GetInt32(5)
                        });
                    }
                }
            }
            return employees;
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_configureManager.ConnectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT Id, Name, Email, Phone, Address, Salary FROM Employees WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new EmployeeDTO
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                Address = reader.GetString(reader.GetOrdinal("Address")),
                                Salary = reader.GetInt32(reader.GetOrdinal("Salary"))
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public async Task AddEmployee(EmployeeDTO newEmployee)
        {
            using (SqlConnection conn = new SqlConnection(_configureManager.ConnectionString))
            {
                await conn.OpenAsync();
                string sql = "INSERT INTO Employees (Name, Email, Phone, Address, Salary) VALUES (@Name, @Email, @Phone, @Address, @Salary)";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@Name", newEmployee.Name);
                    command.Parameters.AddWithValue("@Email", newEmployee.Email);
                    command.Parameters.AddWithValue("@Phone", newEmployee.Phone);
                    command.Parameters.AddWithValue("@Address", newEmployee.Address);
                    command.Parameters.AddWithValue("@Salary", newEmployee.Salary);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateEmployee(EmployeeDTO updatedEmployee)
        {
            using (SqlConnection conn = new SqlConnection(_configureManager.ConnectionString))
            {
                await conn.OpenAsync();
                string sql = "UPDATE Employees SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address, Salary = @Salary WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@Id", updatedEmployee.Id);
                    command.Parameters.AddWithValue("@Name", updatedEmployee.Name);
                    command.Parameters.AddWithValue("@Email", updatedEmployee.Email);
                    command.Parameters.AddWithValue("@Phone", updatedEmployee.Phone);
                    command.Parameters.AddWithValue("@Address", updatedEmployee.Address);
                    command.Parameters.AddWithValue("@Salary", updatedEmployee.Salary);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteEmployee(int employeeId)
        {
            using (SqlConnection conn = new SqlConnection(_configureManager.ConnectionString))
            {
                await conn.OpenAsync();
                string sql = "DELETE FROM Employees WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@Id", employeeId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
