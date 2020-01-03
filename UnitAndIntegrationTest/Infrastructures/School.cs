using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitAndIntegrationTest.Infrastructures
{
    public class School
    {
        [Key] public int Id { get; set; }

        [MaxLength(16)]
        [MinLength(6)]
        [Required]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        
    }
}