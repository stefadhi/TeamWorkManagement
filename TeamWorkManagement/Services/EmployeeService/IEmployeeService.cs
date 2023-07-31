namespace TeamWorkManagement.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee?> GetSingleEmployee(int id);
        Task<List<Employee>> AddEmployee(CreateEmployee request);
        Task<List<Employee>?> UpdateEmployee(int id, Employee request);
        Task<List<Employee>?> DeleteEmployee(int id);
    }
}
