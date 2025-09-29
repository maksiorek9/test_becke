using System.Net;
using backe.models.identiti;
using bake.models.identiti;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace work.controler;

[ApiController]
[Route("[controller]")]

public class Cheker(ChekEmail chekEmail, AuthPerson person): ControllerBase
{
    
    [HttpGet("chek")]
    [Authorize]
    public async Task< IActionResult> Get()
    {
         return Ok(new { Message = "Токен валиден"});
        
    }
    [HttpGet("log")]
    public async Task< IActionResult> logut()
    {
        HttpContext.Response.Cookies.Delete("berr");
        return Ok();
    }
    
    [HttpPost("Chekemaill")]
    public async Task< IActionResult> ChekEmaill( [FromBody] string email)
    {
        if (await chekEmail.chek(email))
        {

            return Ok();
        }

        return BadRequest();

    }
    
    
 
}


