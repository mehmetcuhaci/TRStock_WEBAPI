using Microsoft.EntityFrameworkCore;
using TradingUserMicroService;

var builder = WebApplication.CreateBuilder(args);

// CORS ayarlar�n� yap�land�rma
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 23)); 

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient(); // HttpClient ekledik
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// CORS politikas�n� etkinle�tirme
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
});



//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
