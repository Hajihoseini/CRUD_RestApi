using CRUD_RestAPI.Modeld;
using Microsoft.EntityFrameworkCore;

namespace CRUD_RestAPI.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
