using Microsoft.AspNetCore.Mvc;
using BeautyfulPasswordGeneratorAPI.Models;

namespace BeautyfulPasswordGeneratorAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PassGenController : Controller
{
    string vowels = "aeioyu";
    string consonants = "bcdfghjklmnpqrstwvxz";
    string digits = "0123456789";
    string symbols = "!@#$%^&*()";
    private readonly ILogger<PassGenController> _logger;

    public PassGenController(ILogger<PassGenController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> GetPassword(int len = 16)
    {
        bool useUppercase = true;
        bool useDigits = true;
        string pass = generatePass(len, useUppercase, useDigits);
        return Ok(pass);
    }

    private string generatePass(int len, bool useUppercase, bool useDigits)
    {
        string pass = string.Empty;
        Random r = new Random();
        for (int i = 0; i < len; i++)
        {
            if (i > 0 && i % 4 == 0)
                pass += "-";

            char lastSymbol;
            if (i == 0 || i % 4 == 0)
            {
                pass += getNextSymbol("ab"[r.Next(0, 2)]);
                continue;
            }
            else
            {
                lastSymbol = pass[pass.Length - 1];
            }
            pass += getNextSymbol(lastSymbol);
        }
        if (useDigits)
        {
            int count = r.Next(1, len / 4);
            for(int i = 3; i < pass.Length && count > 0; i += 5){
                pass = pass.Remove(i).Insert(i, digits[r.Next(digits.Length)].ToString()) + pass.Substring(i+1);
                count--;
            }
        }
        if (useUppercase)
        {
            int count = r.Next(1, len / 4);
            for(int i = 0; i < pass.Length && count > 0; i += 5){
                pass = pass.Remove(i).Insert(i, pass[i].ToString().ToUpper()) + pass.Substring(i+1);
                count--;
            }
        }
        return pass;
    }

    private char getNextSymbol(char c)
    {
        Random r = new Random();
        if (vowels.Contains(c))
            return consonants[r.Next(consonants.Length)];
        else
            return vowels[r.Next(vowels.Length)];
    }

}
