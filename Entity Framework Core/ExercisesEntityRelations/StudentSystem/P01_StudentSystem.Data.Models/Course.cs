namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Course
{
    public Course()
    {
        this.Resources = new HashSet<Resource>();
        this.Homeworks = new HashSet<Homework>();
        this.StudentCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.MaxCourseNameLength)]
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public decimal Price { get; set; }

    public ICollection<Resource> Resources { get; set; }

    public ICollection<Homework> Homeworks { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }
}