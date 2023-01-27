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
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);

                    _logger.LogInformation("Iteration:{i}", i);

                    token.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Task Cancelling {companyName}", companyName);
                //throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Final Catch {companyName}", companyName);
                throw;
            }
            
            return $"{companyName}:{DateTime.Now.ToShortTimeString()}";
        }
    }
}