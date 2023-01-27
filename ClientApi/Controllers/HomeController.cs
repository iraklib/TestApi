using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: <HomeController>
        [HttpGet]
        public async Task<string?> GetAsync()
        {
            HttpClient _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7219"),
                Timeout = new TimeSpan(0, 0, 10)
            };
            _httpClient.DefaultRequestHeaders.Clear();

            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(2000);

            try
            {
                using (var response = await _httpClient.GetAsync("api/Service/companies", cancellationTokenSource.Token))
                {
                    response.EnsureSuccessStatusCode();
                    var company = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return company;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Catch {type}", ex.GetType().Name);
            }

            return "NoContent";
        }
    }
}
