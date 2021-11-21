using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<Students> tbl_Student { get; set; }

        public DbSet<Departments> tbl_Department { get; set; }

        public DbSet<Subjects> tbl_Subject { get; set; }

       
    }
}
