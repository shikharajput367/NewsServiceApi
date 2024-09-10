using AutoMapper;
using Business;
using Business.Mapper;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configures HttpClient for INewsService
builder.Services.AddHttpClient<INewsService, NewsService>();

// Adds controllers to the service container
builder.Services.AddControllers();

// Configures DbContext to use SQL Server
builder.Services.AddDbContext<NewsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registers services and repositories with dependency injection
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();

// Configures AutoMapper with the profile assembly
builder.Services.AddAutoMapper(typeof(ArticleProfile).Assembly);

// Configures Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.

// Enable Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enforce HTTPS redirection
app.UseHttpsRedirection();

// Enable authorization
app.UseAuthorization();

// Map controllers to endpoints
app.MapControllers();

// Run the application
app.Run();
