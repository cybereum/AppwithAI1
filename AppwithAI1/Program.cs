using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AppwithAI1.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppwithAI1ContextConnection") ?? throw new InvalidOperationException("Connection string 'AppwithAI1ContextConnection' not found.");

builder.Services.AddDbContext<AppwithAI1Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppwithAI1.Areas.Identity.Data.AppwithAI1User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppwithAI1Context>();

// Add services to the container.
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
