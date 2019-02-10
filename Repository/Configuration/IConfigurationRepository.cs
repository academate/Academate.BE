using System.Collections.Generic;

namespace Repository.Configuration
{
    public interface IConfigurationRepository
    {
        Domain.ValueObjects.Configuration GetByKey(string key);

        IEnumerable<Domain.ValueObjects.Configuration> GetByGroup(string group);
        void Add(Domain.ValueObjects.Configuration configuration);
    }
}
