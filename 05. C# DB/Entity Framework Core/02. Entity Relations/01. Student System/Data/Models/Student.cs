using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(10)]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<StudentCourse> StudentsCourses { get; set; } = null!;
        public ICollection<Homework> Homeworks { get; set; } = null!;
    }
}
