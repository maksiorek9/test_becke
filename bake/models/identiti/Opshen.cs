using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace bake.models.identiti;

public class Opshen
{
    public static string Audins = "MePerson";
    public static string Iuser = "MeProgect";
    const string key = "gkjfgkdfgjkhfkjghghfffffffffffffffffffffffffffffffffffffdfkjhgkjdfhkghdfkjghjkfdhgdfdfds";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
}