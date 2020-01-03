using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace UnitAndIntegrationTest.Infrastructures
{
    public class Student
    {
        [Key] public int Id { get; set; }

        [MaxLength(16)]
        [MinLength(6)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(16)]
        [MinLength(6)]
        [Required]
        public string Username { get; set; }

        [MaxLength(16)]
        [MinLength(6)]
        [Required]
        [Index]
        public string Password { get; set; }

        public int SchoolId { get; set; }
        [ForeignKey(nameof(SchoolId))] public School School { get; set; }
    }


    public class CreateStudentModel
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SchoolId { get; set; }
    }

    public class CreateStudentValidator : AbstractValidator<CreateStudentModel>
    {
        public CreateStudentValidator()
        {
            RuleFor(x => x.Password).NotNull().MinimumLength(6);
            RuleFor(x => x.Username).NotNull().MinimumLength(6);
            RuleFor(x => x.FullName).NotNull().MinimumLength(6);
            RuleFor(x => x.SchoolId).NotNull();
        }
    }
}