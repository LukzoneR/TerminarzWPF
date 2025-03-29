
using System.ComponentModel.DataAnnotations;

namespace Terminarz.Model;
class Event
{
    public int Id { get; set; }
    [Key]
    public string? Name { get; set; }
    [Required]
    public string? Location { get; set; }
    public DateTime Starts { get; set; }
    [Required]
    public DateTime Ends { get; set; }
    [Required]
    public string? Color { get; set; }
    public string? Description { get; set; }
}
