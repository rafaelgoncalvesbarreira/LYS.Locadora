using LYS.Locadora.Application;
using LYS.Locadora.Application.Context;
using LYS.Locadora.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<LocadoraDbContext>(options =>
{
    //options.UseSqlite(builder.Configuration.GetConnectionString("LocadoraDb"));
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

//apply migration
using var scope = app.Services.CreateScope();
var dbcontext = scope.ServiceProvider.GetRequiredService<LocadoraDbContext>();
var pendingMigration = dbcontext.Database.GetPendingMigrations();
if (pendingMigration.Any())
{
    Console.WriteLine("Migrating...");
    dbcontext.Database.Migrate();
    Console.WriteLine("Migrated.");
}
else
{
    Console.WriteLine("Everything is up to date.");
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();