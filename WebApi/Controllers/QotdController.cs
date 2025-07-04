using Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]  // => localhost:1234/api/qotd
[ApiController]
public class QotdController(ILogger<QotdController> logger, IQotdService qotdService) : ControllerBase
{
    [HttpGet] // => localhost:1234/api/qotd
    public async Task<IActionResult> GetQuoteOfTheDay()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDay)} aufgerufen...");

        var qotd = await qotdService.GetQuoteOfTheDayAsync();

        return Ok(qotd);
    }
}