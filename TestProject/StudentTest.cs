using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitAndIntegrationTest.Controllers;
using UnitAndIntegrationTest.Infrastructures;
using Xunit;

namespace TestProject
{
    public class StudentTest
    {
        [Fact]
        public async Task AddStudent_ValidUsername_ReturnBadRequest()
        {
            //arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(AddStudent_ValidUsername_ReturnBadRequest));
            var controller = new StudentController(dbContext);

            //act
            var result = await controller.Add(new CreateStudentModel()
            {
                FullName = "ali",
                Password = "1234567",
                SchoolId = 1,
                Username = "test444"
            });
            var okResult = result as OkResult;
            dbContext.Dispose();

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddStudent_DuplicateUsername_ReturnBadRequest()
        {
            //arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(AddStudent_DuplicateUsername_ReturnBadRequest));
            var controller = new StudentController(dbContext);

            //act
            var result = await controller.Add(new CreateStudentModel()
            {
                FullName = "ali mohamed",
                Password = "12345667",
                SchoolId = 1,
                Username = "test3333"
            });
            var badRequest = result as BadRequestObjectResult;
            dbContext.Dispose();

            //assert
            Assert.NotNull(badRequest);
            Assert.Equal(400, badRequest.StatusCode);
        }

        [Fact]
        public void GetAll_ZeroPage_ReturnBadRequest()
        {
            //arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(GetAll_ZeroPage_ReturnBadRequest));
            var controller = new StudentController(dbContext);

            //act
            var result = controller.GetAll(0);
            var badRequest = result as BadRequestObjectResult;
            dbContext.Dispose();

            //assert
            Assert.NotNull(badRequest);
            if (badRequest != null) Assert.Equal(400, badRequest.StatusCode);
        }

        [Fact]
        public void GetAll_OnePage_ReturnOk()
        {
            //arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(GetAll_OnePage_ReturnOk));
            var controller = new StudentController(dbContext);

            //act
            var result = controller.GetAll(1);
            var okObjectResult = result as OkObjectResult;
            dbContext.Dispose();

            //assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);
        }
        
        [Fact]
        public void GetById_InvalidId_ReturnNotFound()
        {
            //arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(GetById_InvalidId_ReturnNotFound));
            var controller = new StudentController(dbContext);

            //act
            var result = controller.GetById(5);
            var notFound = result as NotFoundObjectResult;
            dbContext.Dispose();
            
            //assert
            Assert.NotNull(notFound);
            Assert.Equal(404,notFound.StatusCode);
        }
        
        [Fact]
        public void GetById_ValidId_ReturnOk()
        {
            //arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(GetById_ValidId_ReturnOk));
            var controller = new StudentController(dbContext);

            //act
            var result = controller.GetById(1);
            var okObjectResult = result as OkObjectResult;
            dbContext.Dispose();
            
            //assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200,okObjectResult.StatusCode);
        }

        [Fact]
        public void Delete_InvalidId_ReturnBadRequest()
        {
            //arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(Delete_InvalidId_ReturnBadRequest));
            var controller = new StudentController(dbContext);

            //act
            var result = controller.Delete(5);
            var badRequestResult = result as BadRequestObjectResult;
            dbContext.Dispose();
            
            //assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(400,badRequestResult.StatusCode);
        }
        
        [Fact]
        // [Theory]
        // [InlineData(1)]
        // [InlineData(2)]
        // [InlineData(3)]
        public void Delete_ValidId_ReturnBadRequest()
        {
            //arrange
            var dbContext = DbContextMocker.GetDbContext(nameof(Delete_ValidId_ReturnBadRequest));
            var controller = new StudentController(dbContext);

            //act
            var result = controller.Delete(1);
            var okObjectResult = result as OkObjectResult;
            dbContext.Dispose();
            
            //assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200,okObjectResult.StatusCode);
        }
    }
}