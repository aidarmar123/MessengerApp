using MessengerApi.Infrastructure.Data;
using MessengerApi.Infrastructure.Notifications;
using Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

// Add services to the container.
builder.AddKeyVaultIfConfigured();
builder.AddApplicationServices();
builder.AddInfrastructureServices();
builder.AddWebServices();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowFlutter", policy => {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("http://localhost:3000") // URL Ú‚ÓÂ„Ó Flutter Web
              .AllowCredentials(); // Œ¡ﬂ«¿“≈À‹ÕŒ ‰Îˇ SignalR
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
    await initialiser.SeedAsync();
}

app.UseHealthChecks("/health");
app.UseStaticFiles();


app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});


app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));
app.MapHub<ChatHub>("/chathub");

//Middleware
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowFlutter");
app.MapControllers();

app.Run();

public partial class Program
{
}
