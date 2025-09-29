using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using backe.models.identiti;
using backe.models;
using MailKit;

namespace backe.models;

public class EmailVer()
{
 

    //string sub=$"<a href={ur}><button>Открыть в новой вкладке</button></a>";
    string mes = $"<h1>Thank you for signing up<h1>"; 
    string Email = "vadimiskovrus2006@gmail.com";
    string password = "ftzv jtwd upqm ckxr";
    public async Task SandnEmailAsync(string email,string pas, string name)
    {
    
        var emailMessage = new MimeMessage();
 
        emailMessage.From.Add(new MailboxAddress("Site administration", Email));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = "Cookie Shope";
        string sub = $"<h3>Here's your <br>password {pas} <br/>name {name}</h6>";
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = mes+sub
        };
        using (var client = new SmtpClient())
             
        {
            await client.ConnectAsync("smtp.gmail.com", 465, true);
            await client.AuthenticateAsync(Email, password );
            await client.SendAsync(emailMessage);
 
     
        }
    }
  
}