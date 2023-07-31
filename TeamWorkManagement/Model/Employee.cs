using System.ComponentModel.DataAnnotations;

namespace TeamWorkManagement.Model
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public required string Name { get; set; }
        public User? User { get; set; }
        public List<EmployeeAssignmentHistory>? EmployeeAssignmentHistories { get; set; }
        public List<TaskToDo>? TasksToDo { get; set; }
    }
}
