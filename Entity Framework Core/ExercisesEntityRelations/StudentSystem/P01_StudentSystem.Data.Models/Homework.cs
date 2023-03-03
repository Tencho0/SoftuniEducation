using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Homework
{
    [Key]
    public int HomeworkId { get; set; }

    [Required]
    [Unicode(false)]
    public string Content { get; set; } = null!;

    [Required]
    public ContentType ContentType { get; set; }

    [Required]
    public DateTime SubmissionTime { get; set; }

    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }

    public Student Student { get; set; } = null!;

    [ForeignKey(nameof(Course))]
    public int CouresId { get; set; }

    public Course Course { get; set; } = null!;
}