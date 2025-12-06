using EventEase.Components;
using EventEase.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register EventService with HttpClient
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(sp.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext?.Request.Scheme + "://" + 
                          sp.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext?.Request.Host.ToString() ?? "http://localhost")
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

// Serve static files from Data folder
app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
