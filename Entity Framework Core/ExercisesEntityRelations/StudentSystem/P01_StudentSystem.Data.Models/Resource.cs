namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;
using Enums;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.MaxResourceNameLength)]
    public string Name { get; set; } = null!;


    [Required]
    [Unicode(false)]
    public string Url { get; set; } = null!;

    [Required]
    public ResourceType ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;
}