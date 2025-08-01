using UDS.Net.Services;
using UDS.Net.Forms.Tests.Runtime.Services;
using UDS.Net.Forms.Tests.Runtime.Data;
using rxNorm.Net.Api.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

var database = "test.db";// ":memory:"; // in-memory

// use sqlite with efcore
builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseSqlite($"Data Source={database}"));

builder.Services.AddScoped<IVisitService, VisitService>();
builder.Services.AddScoped<IParticipationService, ParticipationService>();
builder.Services.AddScoped<IMilestoneService, MilestoneService>();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ILookupService, LookupService>();
builder.Services.AddScoped<IPacketService, PacketService>();

//builder.Services.AddHttpContextAccessor();
//builder.Services.AddSingleton<IRxNormClient, RxNormClient>();

builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Ensure DB is created new at run
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TestDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages(); // enables UDS.Net.Forms endpoints

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

