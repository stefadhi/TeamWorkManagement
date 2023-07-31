using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TeamWorkManagement.Model
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public int? EmployeeID { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; }
    }
}
