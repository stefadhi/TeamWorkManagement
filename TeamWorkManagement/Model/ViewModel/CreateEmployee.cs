namespace TeamWorkManagement.Model.ViewModel
{
    public record struct CreateEmployee(
        string Name, 
        CreateUser User, 
        List<CreateEmployeeAssignmentHistory> EmployeeAssignmentHistories,
        List<CreateTaskToDo> TasksToDo);
}
