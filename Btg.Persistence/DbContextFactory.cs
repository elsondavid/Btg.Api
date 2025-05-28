using Btg.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DbContextFactory : IDesignTimeDbContextFactory<DbContextBase>
{
    public DbContextBase CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContextBase>();
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BtgDb;User Id=xx;Password=xx;TrustServerCertificate=True;");
        return new DbContextBase(optionsBuilder.Options);
    }
}