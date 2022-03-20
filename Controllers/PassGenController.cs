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
    public async Task<IActionResult> GetPassword()
    {
        int len = 16;
        bool useUppercase = true;
        bool useDigits = false;
        string pass = generatePass(len, useUppercase, useDigits);
        return Ok(pass);
    }

    private string generatePass(int len, bool useUppercase, bool useDigits)
    {
        string vowels = "aeioyu";
        string consonants = "bcdfghjklmnpqrstwvxz";
        string pass = string.Empty;
        Random r = new Random();

        for (int i = 0; i < len; i++)
        {
            if (i > 0 && i % 4 == 0)
                pass += "-";
            if (i % 2 == 0)
            {
                pass += consonants[r.Next(consonants.Length)];
            }
            else
            {
                pass += vowels[r.Next(vowels.Length)];
            }

        }

        return pass;
    }

}
