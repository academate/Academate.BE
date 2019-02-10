using Application.Dtos;
using System.Collections.Generic;

namespace Application.Services.AccessControl
{
    public interface IConfigurationService
    {
        ConfigurationDto GetByKey(string key);

        IEnumerable<ConfigurationDto> GetByGroup(string group);
        void Create(ConfigurationDto configurationDto);
    }
}