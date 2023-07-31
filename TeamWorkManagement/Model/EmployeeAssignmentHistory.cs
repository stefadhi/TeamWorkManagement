using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TeamWorkManagement.Model
{
    public class EmployeeAssignmentHistory
    {
        [Key]
        public int ID { get; set; }
        public int? EmployeeID { get; set; }
        public required string Description { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; }
    }
}
