using System.Security.Cryptography;
using backe.models;
using backe.models.identiti;
using backe.models.Repositori;
using bake.Components;
using bake.models;
using bake.models.identiti;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args); 



   
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();




// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<DbModel>(op =>
{
    op.UseNpgsql(builder.Configuration.GetConnectionString("db"));
    //op.UseNpgsql("Host=localhost;Port=5432;Database=Workkk;Username=postgres;Password=11RR22ee");
});

builder.Services.aut(builder.Configuration);
builder.Services.AddScoped<AuthModel>();
builder.Services.AddScoped<EmailVer>();
builder.Services.AddScoped<ChekEmail>();
builder.Services.AddScoped<ChekPassword>();
builder.Services.AddScoped<Person>();


builder.Services.AddScoped<DeviceDetector>();//проверка     на мобилку

builder.Services.AddScoped<cookie>();
builder.Services.AddScoped<BaseUrl>();
builder.Services.AddScoped<AuthPerson>();
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


app.UseCors(builder => builder.AllowAnyOrigin());



//app.UseSwagger();
//app.UseSwaggerUI();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapControllers();

app.Run();
