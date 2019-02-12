using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public interface IConfigurationRepository
    {
        Task<Domain.ValueObjects.Configuration> GetByKey(string key);

        Task<IEnumerable<Domain.ValueObjects.Configuration>> GetByGroup(string @group);

        Task Add(Domain.ValueObjects.Configuration configuration);
    }
}
