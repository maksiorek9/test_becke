using backe.models;
using backe.models.Repositori;
using bake.models.Repositori;
using Microsoft.EntityFrameworkCore;

namespace bake.models.identiti;

public class ChekEmail(DbModel dbModel) :Chek
{
    public async Task<bool> chek(string email)
    {
        if (await dbModel.work.FirstOrDefaultAsync(u=>u.Email==email)!= null)
        {
            return false;
        }
        return true;

    }
}