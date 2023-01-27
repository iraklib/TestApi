using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        // GET: api/<HomeController>
        [HttpGet]
        public async Task<string?> GetAsync()
        {
            HttpClient _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7219"),
                Timeout = new TimeSpan(0, 0, 1)
            };
            _httpClient.DefaultRequestHeaders.Clear();

            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(2000);

            using (var response = await _httpClient.GetAsync("api/Service/companies", cancellationTokenSource.Token))
            {
                response.EnsureSuccessStatusCode();
                var company = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return company;
            }
        }
    }
}
