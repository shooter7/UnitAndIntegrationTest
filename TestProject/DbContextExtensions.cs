using Microsoft.EntityFrameworkCore;
using UnitAndIntegrationTest;
using UnitAndIntegrationTest.Infrastructures;

namespace TestProject
{
    public static class DbContextExtensions
    {
        public static void Seed(this TestDbContext context)
        {
            context.Students.Add(new Student()
            {
                Id=1,
                FullName = "ali mohammed",
                Username = "test123",
                Password = "1232312",
                School = new School()
                {
                    Id = 1,
                    Name = "test school"
                }
            });
            
            
            context.Students.Add(new Student()
            {
                Id=2,
                FullName = "ali mohammed",
                Username = "test22222",
                Password = "1232312",
                School = new School()
                {
                    Id = 2,
                    Name = "2test school"
                }
            });
            
            context.Students.Add(new Student()
            {
                Id=3,
                FullName = "ali mohammed",
                Username = "test3333",
                Password = "1232312",
                SchoolId = 1
            });

            context.SaveChanges();
        }
    }
}