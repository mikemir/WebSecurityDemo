using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebSecurityDemo.Models;
using WebSecurityDemo.Utils;

namespace WebSecurityDemo.Controllers
{
    [AllowAnonymous]
    public class CspReportController : Controller
    {
        private readonly ILoggerManager _logger;
        public CspReportController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Index([FromBody] CspReportRequest cspReportRequest)
        {
            _logger.LogWarn(JsonConvert.SerializeObject(cspReportRequest));

            return Ok();
        }
    }
}
