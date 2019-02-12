using Domain.DbContext;
using System;

namespace CrossCuttingServices
{
    public interface IDbProvider : IDisposable
    {
        AcademateDbContext Context { get; }
    }
}