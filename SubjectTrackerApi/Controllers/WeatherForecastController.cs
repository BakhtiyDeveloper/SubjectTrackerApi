//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Microsoft.AspNetCore.Mvc;
using SubjectTrackerApi.Brokers;
using SubjectTrackerApi.Models;

namespace SubjectTrackerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IStorageBroker storageBroker;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task <IEnumerable<WeatherForecast>> Get()
        {
            Subject subject = new Subject();
            subject.Name = "Baxtiyor"; 
            subject.Id = Guid.NewGuid();
            await storageBroker.InsertSubjectAsync(subject);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
