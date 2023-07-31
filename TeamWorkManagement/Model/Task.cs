using System.Text.Json.Serialization;

namespace TeamWorkManagement.Model
{
    public class TaskToDo
    {
        public int ID { get; set; }
        public required string Description { get; set; }
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
