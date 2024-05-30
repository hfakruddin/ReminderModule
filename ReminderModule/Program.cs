﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReminderModule.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ReminderModuleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReminderModuleContext") ?? throw new InvalidOperationException("Connection string 'ReminderModuleContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reminders}/{action=Index}/{id?}");

app.Run();
