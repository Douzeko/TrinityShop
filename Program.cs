using Microsoft.EntityFrameworkCore;
using TrinityShop.Models;
using TrinityShop.Services.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextTrinity>(options =>
    options.UseNpgsql(builder.Configuration["conectionstrings:local"]));
builder.Services.AddScoped<IDbContextTrinity, DbContextTrinity>();
builder.Services.AddScoped<ClientService>();
    var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dataContext = services.GetRequiredService<DbContextTrinity>();
    dataContext.Database.Migrate();
}
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

