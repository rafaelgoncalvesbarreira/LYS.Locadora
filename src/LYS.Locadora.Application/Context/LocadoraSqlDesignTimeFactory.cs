using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LYS.Locadora.Application.Context;

public class LocadoraSqlDesignTimeFactory: IDesignTimeDbContextFactory<LocadoraDbContext>
{
    public LocadoraDbContext CreateDbContext(string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentException("ConnectionString is missing");
        }
        var optionsBuilder = new DbContextOptionsBuilder<LocadoraDbContext>();
        var connectionString = args[0];
        optionsBuilder.UseNpgsql(connectionString );
        
        return new LocadoraDbContext(optionsBuilder.Options);
    }
}