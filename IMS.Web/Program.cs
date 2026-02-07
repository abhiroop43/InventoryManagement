using IMS.Infrastructure;
using IMS.Infrastructure.Data.Extensions;
using IMS.UseCases;
using IMS.Web;
using IMS.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddUseCaseServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddWebServices(builder.Configuration);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

if (app.Environment.IsDevelopment())
    await app.InitializeDatabaseAsync();

await app.RunAsync();
