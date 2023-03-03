namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using Common;

public class Student
{
    public Student()
    {
        this.Homeworks = new HashSet<Homework>();
        this.StudentCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.MaxStudentNameLength)]
    public string Name { get; set; } = null!;

    [Unicode(false)]
    [MaxLength(ValidationConstants.StudentPhoneNumberLength)]
    [MinLength(ValidationConstants.StudentPhoneNumberLength)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public DateTime RegisteredOn { get; set; }

    public DateTime Birthday { get; set; }

    public ICollection<Homework> Homeworks { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }
}
