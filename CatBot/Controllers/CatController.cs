using Microsoft.AspNetCore.Mvc;
using SimpleCatBot.Helpers;


[ApiController]
[Route("[controller]")]
public class CatController : ControllerBase
{
    private readonly CatBotHAndler _catBotService;

    public CatController(CatBotHAndler catBotService)
    {
        _catBotService = catBotService;
    }

    [HttpGet("start")]
    public IActionResult Start()
    {
        Task.Run(() => _catBotService.StartBot());

        return Ok("CatBot started.");
    }

    [HttpGet("stop")]
    public IActionResult Stop()
    {
        _catBotService.StopBot();
        return Ok("CatBot stopped.");
    }

}

