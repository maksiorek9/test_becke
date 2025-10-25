using backe.models;
using backe.models.identiti;
using bake.models;
using Microsoft.AspNetCore.Mvc;

namespace bake.controlrs;


[ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]")]
public class AutheControlers(AuthModel authModel, EmailVer emailVer): ControllerBase
{
    

    [HttpPost("Registr")]
    public async Task<IActionResult> reg([FromBody] AuthPerson person)
    {
        var toke = await authModel.regist(person);
        
         HttpContext.Response.Cookies.Append("berr",toke);
         return Ok(toke);
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Log([FromBody] Logperson person)
    {
        var toke = await  authModel.login(person);
        
         HttpContext.Response.Cookies.Append("berr",toke);
         Console.WriteLine(toke);
        return Ok(toke);
    }
    [HttpPost("test")]
    public async Task<IActionResult> Leg([FromBody] AuthPerson person)
    {
        await emailVer.SandnEmailAsync(person.Email, person.Password, person.Name);
        
        
        return Ok("4343");
    }
}



