using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace work.controler;

[ApiController]
[Route("[controller]")]

public class Good_wordControler(): ControllerBase
{
    
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
         return Ok(new { Message = "Токен валиден",});
        
    }

    
 
}


