
using System.ComponentModel.DataAnnotations;

namespace Terminarz.Model;
public class Event
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; } = string.Empty;
    public string? Location { get; set; }
    [Required]
    public DateTime Starts { get; set; }
    [Required]
    public DateTime Ends { get; set; }
    public string? Color { get; set; }
    public string? Description { get; set; }
}
