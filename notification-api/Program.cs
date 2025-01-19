using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using notification_api;
using notification_api.Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IEmailRepository, EmailRepository>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddCors(options => options.AddPolicy("EnableAll", cors =>
{
    cors.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
}));
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("database")));
builder.Services.AddHttpContextAccessor(); 

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseResponseCaching();

app.UseCors("EnableAll");

app.MapControllers();



app.Run();
