using Exobry.Examples.AD_GraphQL_EF.Infrastructure;
using Exobry.Examples.AD_GraphQl_EF.Server.Schema.ToDoList;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureInfrastructureServices(builder.Configuration);

builder.Services.AddGraphQLServer()
    .AddQueryType<ToDoListQueryType>();

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

app.UseRouting()
    .UseEndpoints(endpoints => {
        endpoints.MapGraphQL();
    });

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
