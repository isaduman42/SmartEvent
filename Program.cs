using Microsoft.EntityFrameworkCore;
using SmartEvent.API.Data;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

var builder = WebApplication.CreateBuilder(args);

// Render port ayarı
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

try
{
    var credential = GoogleCredential.FromFile("firebase-key.json");
    Console.WriteLine("✅ Firebase credential loaded.");

    FirebaseApp.Create(new AppOptions()
    {
        Credential = credential
    });
    Console.WriteLine("✅ Firebase initialized successfully.");
}
catch (Exception ex)
{
    Console.WriteLine("❌ Firebase init failed:");
    Console.WriteLine(ex.ToString()); // Tüm stack trace'i yaz
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapControllers(); 
app.Run();