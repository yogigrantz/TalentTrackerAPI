using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TalentTrack.Controllers
{

    [ApiController]
    public class OpenController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Home()
        {
            string? httpReferrer = this.HttpContext.GetServerVariable("HTTP_REFERER");
            if (httpReferrer == null)
            {
                httpReferrer = this.HttpContext.GetServerVariable("REMOTE_HOST");
                if (httpReferrer == null)
                    httpReferrer = this.HttpContext.GetServerVariable("REMOTE_ADDR");
            }
            httpReferrer = this.HttpContext.GetServerVariable("REMOTE_ADDR");

            return Ok($"Home - c# .net 8 WebAPI V1.1 TDD / DEVOPS / CI / CD Pipelines / App Services. Your IPAddress is: {httpReferrer} - 20002026!");
        }
    }
}
