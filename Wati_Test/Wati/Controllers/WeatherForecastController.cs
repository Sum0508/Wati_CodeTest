using Microsoft.AspNetCore.Mvc;

namespace Wati.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private IRepo _Repo;
        
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepo repo)
        {
            _logger = logger;
            _Repo = repo;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("/add")]
        public IActionResult Sum([FromBody] Request req)
        {
            var result = AddCode(req.Num1, req.Num2);

            this._Repo.Add(req.Num1, req.Num2, result);

            return this.Ok(result);
        }

        public int AddCode(int n1, int n2)
        {
            return n1 + n2;
        }
    }
}