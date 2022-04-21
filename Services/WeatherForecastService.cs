using Microsoft.EntityFrameworkCore;
using BlazorCRUD.Data.DbContexts;
using BlazorCRUD.Data.Models;

namespace BlazorCRUD.Services;

public class WeatherForecastService
{
    // public WeatherForecastService()
    // { }

    public async Task<List<WeatherForecast>> GetWeatherForecastsAsync(ApplicationDbContext DbContext)
    {
        return await DbContext.WeatherForecasts.ToListAsync();
    }
}
