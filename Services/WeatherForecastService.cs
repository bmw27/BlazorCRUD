using Microsoft.EntityFrameworkCore;
using BlazorCRUD.Data.DbContexts;
using BlazorCRUD.Data.Models;

namespace BlazorCRUD.Services;

public class WeatherForecastService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public WeatherForecastService(IDbContextFactory<ApplicationDbContext> ContextFactory)
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
