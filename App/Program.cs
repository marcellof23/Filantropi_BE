using Microsoft.EntityFrameworkCore;
using if3250_2022_19_filantropi_backend.Models;
using if3250_2022_19_filantropi_backend.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseInMemoryDatabase("UserList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
