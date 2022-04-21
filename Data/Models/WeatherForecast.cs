using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorCRUD.Data.Models;

public class WeatherForecast
{
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }
}
