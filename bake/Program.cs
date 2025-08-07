using backe.controlrs;
using backe.models;
using backe.models.identiti;
using bake.Components;
using Microsoft.EntityFrameworkCore;






var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<DbModel>(op =>
{
    //op.UseNpgsql(builder.Configuration.GetConnectionString("db"));
    op.UseNpgsql("Host=localhost;Port=5432;Database=Workkk;Username=postgres;Password=11RR22ee");
});

builder.Services.aut(builder.Configuration);
builder.Services.AddScoped<AuthModel>();
builder.Services.AddScoped<Person>();
builder.Services.AddScoped<JWTModel>();
builder.Services.AddControllers();


//builder.Services.AddSwaggerGen();
//builder.Services.AddCors(op =>
//{
//
//});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}


//app.UseCors(builder => builder.AllowAnyOrigin());



//app.UseSwagger();
//app.UseSwaggerUI();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapControllers();

app.Run();