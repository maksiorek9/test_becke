using backe.models;
using backe.models.identiti;
using Microsoft.AspNetCore.Mvc;

namespace backe.controlrs;


[ApiController]
[Route("[controller]")]
public class AutheControlers(AuthModel authModel): ControllerBase
{
    [HttpPost("Registr")]
    public IActionResult reg([FromBody] RegPerson person)
    {
        authModel.regist(person);
        return NoContent();
    }
    
    [HttpPost("Login")]
    public IActionResult Log(string email, string pasword)
    {
        var toke = authModel.login(email, pasword);
        HttpContext.Response.Cookies.Append("berr",toke);
        return Ok(toke);
    }
}