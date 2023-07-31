using Microsoft.EntityFrameworkCore;
using TeamWorkManagement.Model;

namespace TeamWorkManagement.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TWMdb;Trusted_Connection=true;TrustServerCertificate=true;");
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAssignmentHistory> EmployeeAssignmentHistories { get; set; }
        public DbSet<TaskToDo> TasksToDo { get; set; }
    }
}
