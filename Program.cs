using Microsoft.EntityFrameworkCore;
using SmartEvent.API.Data;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

var firebasePath = Path.Combine(Directory.GetCurrentDirectory(), "firebase-key.json");
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(firebasePath)
});

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();