using Microsoft.AspNetCore.Mvc;
using BeautyfulPasswordGeneratorAPI.Models;

namespace BeautyfulPasswordGeneratorAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PassGenController : Controller
{
    private readonly ILogger<PassGenController> _logger;

    public PassGenController(ILogger<PassGenController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> GetPassword(){
        string pass = "abcdefg";
        return Ok(pass);
    }

}
