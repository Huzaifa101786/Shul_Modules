using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Shul_Modules.Data;
using Shul_Modules.Services;
using QuestPDF.Infrastructure;
using Auth0.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<WeatherForecastService>();
// Register the MemberService
builder.Services.AddScoped<MemberService>();
builder.Services.AddSignalR();
builder.Services.AddScoped<PdfService>();

QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ?? new code
app.UseAuthorization();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapHub<BlastsHub>("/blastshub");

app.Run();
