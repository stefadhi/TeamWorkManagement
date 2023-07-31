namespace TeamWorkManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            return await _employeeService.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            var result = await _employeeService.GetSingleEmployee(id);
            if (result is null)
                return NotFound("Employee not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(CreateEmployee request)
        {
            var result = await _employeeService.AddEmployee(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(int id, Employee request)
        {
            var result = await _employeeService.UpdateEmployee(id, request);
            if (result is null)
                return NotFound("Employee not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            if (result is null)
                return NotFound("Employee not found.");

            return Ok(result);
        }
    }
}
