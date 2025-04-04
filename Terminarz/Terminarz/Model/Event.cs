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

    public int Column => (int)Starts.DayOfWeek - (int)DayOfWeek.Monday;

    public int Row
    {
        get
        {
            int baseRow = Starts.Hour;
            if ((Ends - Starts).TotalHours <= 1) 
                return baseRow - 1;
            return baseRow;
        }
    }

    public int RowSpan => (int)Math.Ceiling((Ends - Starts).TotalHours);

    public int GetColumn(DateTime currentWeekStart)
    {
        int dayDifference = (int)(Starts.Date - currentWeekStart.Date).TotalDays;

        return dayDifference >= 0 && dayDifference < 7 ? dayDifference : -1;
    }
}