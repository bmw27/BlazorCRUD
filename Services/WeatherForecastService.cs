using BlazorCRUD.Data;
using BlazorCRUD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Services;

public class WeatherForecastService
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public WeatherForecastService(IDbContextFactory<AppDbContext> ContextFactory)
    {
        _contextFactory = ContextFactory;
    }

    public async Task<List<WeatherForecast>> GetWeatherForecastsAsync()
    {
        using (var ctx = _contextFactory.CreateDbContext())
        {
            return await ctx.WeatherForecasts.ToListAsync();
        }
    }

    public async Task CreateWeatherForecastAsync(WeatherForecast forecast)
    {
        using (var ctx = _contextFactory.CreateDbContext())
        {
            ctx.WeatherForecasts.Add(forecast);
            await ctx.SaveChangesAsync();
        }
    }
}
