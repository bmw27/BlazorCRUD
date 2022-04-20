using Microsoft.EntityFrameworkCore;
using BlazorCRUD.Data.DbContexts;
using BlazorCRUD.Data.Models;

namespace BlazorCRUD.Services;

public class WeatherForecastService
{
    private readonly ApplicationDbContext _context;

    public WeatherForecastService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<WeatherForecast>> GetWeatherForecastsAsync() => await _context.WeatherForecasts.ToListAsync();
}
