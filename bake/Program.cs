using backe.controlrs;
using backe.models;
using backe.models.identiti;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DbModel>(op =>
{
    op.UseNpgsql(builder.Configuration.GetConnectionString("db"));
});
//Host=;Port=5432;Database=Workkk;Username=postgres;Password=11RR22ee
//builder.Configuration.GetConnectionString("db")
builder.Services.aut(builder.Configuration);
builder.Services.AddScoped<AuthModel>();
builder.Services.AddScoped<Person>();
builder.Services.AddScoped<JWTModel>();
builder.Services.AddControllers();


builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.






app.UseSwagger();
app.UseSwaggerUI();





app.MapControllers();

app.Run();