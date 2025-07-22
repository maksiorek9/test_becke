using backe.models.identiti;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backe.models;

public class AuthModel(DbModel db , JWTModel jwtModel)
{
    public void regist(RegPerson regPerson)
    {
        Person person = new Person()
        {
            Id = Guid.Empty,
            Email = regPerson.Email,
            Name = regPerson.Name
        };
        person.PasswordSh = new PasswordHasher<Person>()
            .HashPassword(person, regPerson.Pasword);
        db.Add(person);
        db.SaveChanges();
    }

    public string login(string Email, string pasword)
    {
        Person? person = db.work.FirstOrDefault(o => Email == o.Email);
        
        
        if (person== null)
        {
            //Console.WriteLine(jwtModel.getJWT(person));
            return person.PasswordSh+ "" + person.Email;
            throw new Exception("no person");
        }
        var inf = new PasswordHasher<Person>()
            .VerifyHashedPassword(person, person.PasswordSh, pasword);
        if (inf == PasswordVerificationResult.Success)
        {
            return jwtModel.getJWT(person);
        }
        else
        {
            return "no";
        }
    }
}