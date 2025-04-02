using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HwController : Controller {
    readonly IHwService hwService;
    private readonly ILogger<HwController> _logger;

    public HwController(IHwService service, ILogger<HwController> logger) {
        _logger = logger;
        hwService = service;
    }

    [HttpGet]
    public IActionResult GetHelloWorld() {
        return Ok(hwService.SayHello());
    }
}