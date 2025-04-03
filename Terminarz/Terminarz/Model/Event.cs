using System.ComponentModel.DataAnnotations;
using System;

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

    // Właściwości pomocnicze do pozycjonowania w terminarzu
    public int Column
    {
        get
        {
            // Poniedziałek=0, Wtorek=1, ..., Niedziela=6
            return (int)Starts.DayOfWeek - (int)DayOfWeek.Monday;
        }
    }

    public int Row
    {
        get
        {
            // Godzina 8:00 = wiersz 8 (indeksowanie od 0)
            return Starts.Hour;
        }
    }

    public int RowSpan
    {
        get
        {
            // Zaokrąglenie w górę do pełnych godzin
            double hours = (Ends - Starts).TotalHours;
            return (int)Math.Ceiling(hours);
        }
    }


}