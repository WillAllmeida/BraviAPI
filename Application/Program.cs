using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure.Configurations;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Domain.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContactBookContext>();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
