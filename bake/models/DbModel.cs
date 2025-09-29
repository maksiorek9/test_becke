using backe.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bake.models;

public class DbModel: IdentityDbContext
{
    public DbSet<Person> work => Set<Person>();

    public DbModel(DbContextOptions<DbModel> options) : base(options)
    {
        Database.EnsureCreatedAsync();
    }
}