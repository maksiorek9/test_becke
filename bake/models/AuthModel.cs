using backe.models;
using backe.models.identiti;
using bake.models.identiti;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace bake.models;

public class AuthModel(DbModel db , JWTModel jwtModel, ChekPassword chekPassword, ChekEmail chekEmail)
{
    public async Task<string> regist(AuthPerson regPerson)
    {
        if (await chekEmail.chek(regPerson.Email)== false)
        {
            return "fdfsdfs";
        }
        Person person = new Person()
        {
            Id = Guid.Empty,
            Email = regPerson.Email,
            Name = regPerson.Name
        };
        person.Password = new PasswordHasher<Person>()
            .HashPassword(person, regPerson.Password);
       await db.AddAsync(person);
       await db.SaveChangesAsync();
            return jwtModel.getJWT(person);
        
    }

    public async  Task<string> login(Logperson pr)
    {
        Person? person = await  db.work.FirstOrDefaultAsync(o => pr.Email == o.Email);
        
        
        if (person== null)
        {
            //Console.WriteLine(jwtModel.getJWT(person));
            return "1";
            
        }
        
        return chekPassword.chek(pr.Password,person) ? jwtModel.getJWT(person) : "no";
    }
}