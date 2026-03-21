using LYS.Locadora.Application.Model;
using Microsoft.EntityFrameworkCore;

namespace LYS.Locadora.Application.Context;

public class LocadoraDbContext(DbContextOptions<LocadoraDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
}