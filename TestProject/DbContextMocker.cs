using Microsoft.EntityFrameworkCore;
using UnitAndIntegrationTest;

namespace TestProject
{
    public static class DbContextMocker
    {
        public static TestDbContext GetDbContext(string dbName)
        {
            var options=new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(dbName).Options;
            
            var dbContext=new TestDbContext(options);
            dbContext.Seed();
            return dbContext;
        }
    }
}