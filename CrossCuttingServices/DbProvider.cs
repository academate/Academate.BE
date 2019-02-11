using Domain.DbContext;
using Microsoft.EntityFrameworkCore;
using System;

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
            catch (Exception)
            {
                // ignored
            }
        }
    }

    public interface IDbProvider : IDisposable
    {
        AcademateDbContext Context { get; }
    }
}
