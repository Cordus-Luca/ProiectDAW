using Microsoft.AspNetCore.Mvc;

namespace ProiectRestanta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new List<string>
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // CRUD

        // C - CREATE       - POST
        // R - READ         - GET
        // U - UPDATE       - PUT/PATCH
        // D - DELETE       - DELETE

        [HttpGet]
        public async Task<IActionResult> GetSummaries()
        {
            return Ok(Summaries);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSummaries()
        {
            string newSummary = "Vara";

            Summaries.Add(newSummary);

            return Ok(Summaries);
        }

        [HttpDelete]
        [Route("{type}")]
        public async Task<IActionResult> DeleteSummaries(string type)
        {

            Summaries.Remove(type);

            return Ok(Summaries);
        }

        [HttpPut]
        [Route("{type}")]
        public async Task<IActionResult> UpdateSummaries(string type)
        {

            Summaries[0]  = type;

            return Ok(Summaries);
        }
        // 200 - OK
        // 204 - NoContent

        // 404 - NotFound
        // 400 - BadRequest

        // 500 - Internal Server Error


    }
}