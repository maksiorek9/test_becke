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
        return Ok("ww");
    }
    
    [HttpPost("Login")]
    public IActionResult Log([FromBody] RegPerson person)
    {
        var toke = authModel.login(person.Email, person.Pasword);
        HttpContext.Response.Cookies.Append("berr",toke);
        return Ok(toke);
    }
}