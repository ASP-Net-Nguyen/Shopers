using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shopers.Data;
using Shopers.Models.Authentication;
using Shopers.Service.CategoryService;
using Shopers.Service.LoginService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// For Identity  
builder.Services.AddIdentity<ProfileUser, IdentityRole>()
    .AddEntityFrameworkStores<DataDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ILoginService, LoginService>(); 
builder.Services.AddScoped<ICategoryService, CategoryService>();

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
