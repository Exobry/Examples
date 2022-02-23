using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var smtpClient = new SmtpClient();
var configSection = builder.Configuration.GetSection(nameof(smtpClient));
smtpClient.Host = configSection["Host"];
smtpClient.Port = int.Parse(configSection["Port"]);
smtpClient.EnableSsl = bool.Parse(configSection["SslEnabled"]);
smtpClient.Credentials = new NetworkCredential(configSection["Email"], configSection["Password"]);

builder.Services.AddFluentEmail(configSection["Email"])
    .AddRazorRenderer()
    .AddSmtpSender(smtpClient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
