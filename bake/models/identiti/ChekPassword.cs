using backe.models;
using Microsoft.AspNetCore.Identity;

namespace bake.models.identiti;

public class ChekPassword()
{
    public  bool chek(string pas, Person person)
    {
        var inf = new PasswordHasher<Person>()
            .VerifyHashedPassword(person, person.Password, pas);
        if (inf == PasswordVerificationResult.Success)
        {
            return true;
        }
        
        return false;
        
    }
}