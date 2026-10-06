using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class ServiceRequest
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [RegularExpression("Low|Medium|High")]
    public string Priority { get; set; } = "Medium";

    [Required]
    [RegularExpression("Pending|In Progress|Completed")]
    public string Status { get; set; } = "Pending";

    [Required]
    public int UserId { get; set; }

    public User? User { get; set; }

    public string? AssignedTo { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}