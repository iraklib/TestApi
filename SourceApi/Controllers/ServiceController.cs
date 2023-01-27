using Microsoft.AspNetCore.Mvc;

namespace SourceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
       

        private readonly ILogger<ServiceController> _logger;

        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{companyName}", Name = "GetCompanyName")]
        public ActionResult<string> GetCompanyName(string companyName, CancellationToken token)
        {
            var counter = 1;
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                _logger.LogInformation("Iteration:{counter}", counter);
                token.ThrowIfCancellationRequested();
                counter++;
            }
            
            return $"{companyName}:{counter}";
        }
    }
}