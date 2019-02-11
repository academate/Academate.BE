using Domain.DbContext;
using Microsoft.EntityFrameworkCore;

namespace CrossCuttingServices
{
    public class DbProvider : IDbProvider
    {
        public AcademateDbContext Context { get; }

        public DbProvider()
        {
            var builder = new DbContextOptionsBuilder<AcademateDbContext>();
            builder.UseInMemoryDatabase("AcademateDb");
            var options = builder.Options;

            Context = new AcademateDbContext(options);
        }

        public void Dispose()
        {
            try
            {
                Context?.SaveChanges();
            }
            finally
            {
                Context?.Dispose();
            }
        }
    }
}
