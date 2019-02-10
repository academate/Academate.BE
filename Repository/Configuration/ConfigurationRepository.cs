using Domain.Exception;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Configuration
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public static List<Domain.ValueObjects.Configuration> _Configurations = new List<Domain.ValueObjects.Configuration>();

        public Domain.ValueObjects.Configuration GetByKey(string key)
        {
            var configuration = _Configurations.FirstOrDefault(c => c.Key == key);
            return configuration;
        }

        public IEnumerable<Domain.ValueObjects.Configuration> GetByGroup(string group)
        {
            var configurations = _Configurations.Where(c => c.Group == group);
            return configurations;
        }

        public void Add(Domain.ValueObjects.Configuration configuration)
        {
            var isKeyUsed = _Configurations.Any(c => c.Key == configuration.Key);

            if (isKeyUsed)
                throw new DuplicationKey("Key already used!");

            _Configurations.Add(configuration);

        }
    }
}