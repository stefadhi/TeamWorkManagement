using TeamWorkManagement.Model;

namespace TeamWorkManagement.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDBContext _context;

        public EmployeeService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> AddEmployee(CreateEmployee request)
        {
            var employee = new Employee { Name = request.Name };

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.User.Password);

            var user = new User { Username = request.User.Username, PasswordHash = passwordHash, Employee = employee };
            var empasshist = request.EmployeeAssignmentHistories.Select(w => new EmployeeAssignmentHistory { Description = w.Description, Employee = employee }).ToList();
            var tasktodo = request.TasksToDo.Select(f => new TaskToDo { Description = f.Description, Employees = new List<Employee> { employee } }).ToList();

            employee.User = user;
            employee.EmployeeAssignmentHistories = empasshist;
            employee.TasksToDo = tasktodo;

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return await _context.Employees.Include(x => x.User).Include(x => x.EmployeeAssignmentHistories).Include(x => x.TasksToDo).ToListAsync();
        }

        public async Task<List<Employee>?> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
                return null;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            //var employees = await _context.Employees.ToListAsync();
            //return employees;
            return await _context.Employees.Include(x => x.User).Include(x => x.EmployeeAssignmentHistories).Include(x => x.TasksToDo).ToListAsync();
        }

        public async Task<Employee?> GetSingleEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
                return null;

            return employee;
        }

        public async Task<List<Employee>?> UpdateEmployee(int id, Employee request)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
                return null;

            employee.Name = request.Name;

            await _context.SaveChangesAsync();

            return await _context.Employees.ToListAsync();
        }
    }
}
