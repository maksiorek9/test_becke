using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using backe.models.identiti;
using bake.models.identiti;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace bake.models;

public class JWTModel
{
    
   
    
    public  string getJWT(Person person)
    {
        var clam = new List<Claim>()
        {
            new Claim("IdUser", person.Id.ToString()),
            new Claim("UserName", person.Email),
            new Claim("UserEmail", person.Name)
        };
        var jwt = new JwtSecurityToken(
            issuer: Opshen.Iuser,
            claims: clam,
            audience: Opshen.Audins,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(2)),
            signingCredentials: new SigningCredentials
                (Opshen.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha384)
        );
        string resolt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return resolt;
    }
}