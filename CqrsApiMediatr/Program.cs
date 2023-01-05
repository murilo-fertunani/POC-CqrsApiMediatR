using CqrsApiMediatr.Common.Extensions;
using CqrsApiMediatr.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql("Host=localhost;Port=5433;Database=cqrsapi;Username=postgres;Password=postgres"));
builder.Services.AddDependencyInjections();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(u =>
    {
        u.SwaggerEndpoint(string.Format("/swagger/v1/swagger.json"), string.Format("CqrsApi V1"));
        u.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
