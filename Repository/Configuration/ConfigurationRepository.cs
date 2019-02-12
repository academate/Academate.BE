using CrossCuttingServices;
using Domain.DbContext;
using Domain.Exception;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly AcademateDbContext _dbContext;

        public ConfigurationRepository(IDbProvider dbProvider)
        {
            _dbContext = dbProvider.Context;
        }

        public async Task<Domain.ValueObjects.Configuration> GetByKey(string key)
        {
            var configuration = await _dbContext.Configurations
                                                .FirstOrDefaultAsync(c => c.Key == key);
            return configuration;
        }

        public async Task<IEnumerable<Domain.ValueObjects.Configuration>> GetByGroup(string @group)
        {
            var configurations = await _dbContext.Configurations
                                            .Where(c => c.Group == group)
                                            .ToArrayAsync();
            return configurations;
        }

        public async Task Add(Domain.ValueObjects.Configuration configuration)
        {
            var isKeyUsed = await _dbContext.Configurations.AnyAsync(c => c.Key == configuration.Key);

            if (isKeyUsed)
                throw new DuplicationKey("Key already used!");

            await _dbContext.Configurations.AddAsync(configuration);
        }
    }
}