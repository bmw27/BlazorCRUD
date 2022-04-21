using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorCRUD.Data.Models;
using Bogus;

namespace BlazorCRUD.Data
{
    public partial class AppDbContext : DbContext
    {
        public virtual DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var id = 1;
            var forecasts = new Faker<WeatherForecast>()
                .RuleFor(m => m.Id, f => id++)
                .RuleFor(m => m.Date, f => f.Date.Past())
                .RuleFor(m => m.TemperatureC, f => f.Random.Int(-20, 55))
                .RuleFor(m => m.Summary, f => f.PickRandom(summaries));

            modelBuilder.Entity<WeatherForecast>().HasData(forecasts.GenerateBetween(1000, 1000));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
