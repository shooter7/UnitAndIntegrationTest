using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnitAndIntegrationTest.Infrastructures;

namespace UnitAndIntegrationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly TestDbContext _db;
        private const int Take = 10;

        public StudentController(TestDbContext db)
        {
            _db = db;
        }


        [HttpPost]
        public async Task<IActionResult> Add( CreateStudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

            if (_db.Students.Any(x => x.Username == model.Username))
                return BadRequest(new
                {
                    message = "duplicate user name"
                });

            var student = new Student()
            {
                FullName = model.FullName,
                Username = model.Username,
                Password = model.Password,
                SchoolId = model.SchoolId
            };

            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll(int page)
        {
            if (page <= 0)
                return BadRequest(new
                {
                    message = "page must bigger then zero"
                });
            page -= 1;
            page *= Take;
            return Ok(_db.Students.Include(x => x.School).Skip(page).Take(10).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _db.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound(new
                {
                    message="student not found"
                });
            }
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _db.Students.FirstOrDefault(x => x.Id == id);
            if (student==null)
            {
                return BadRequest(new
                {
                    message = "student not found"
                });
            }

            _db.Entry(student).State = EntityState.Deleted;
            _db.SaveChanges();
            return Ok(new
            {
                message = "student"+id+" deleted"
            });
        }
        
    }
}