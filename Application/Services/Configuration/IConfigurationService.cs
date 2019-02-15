using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.AccessControl
{
    public interface IConfigurationService
    {
        Task<ConfigurationDto> GetByKey(string key);

        Task<IEnumerable<ConfigurationDto>> GetByGroup(string @group);
        Task Create(ConfigurationDto configurationDto);
    }
}