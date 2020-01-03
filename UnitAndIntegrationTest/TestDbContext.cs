using Microsoft.EntityFrameworkCore;
using UnitAndIntegrationTest.Infrastructures;

namespace UnitAndIntegrationTest
{
    public class TestDbContext:DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
            
        }
        

        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}