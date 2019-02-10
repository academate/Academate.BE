using Application.Dtos;
using Domain.ValueObjects;
using Repository.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.AccessControl
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public ConfigurationDto GetByKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;

            var configuration = _configurationRepository.GetByKey(key);
            var configurationDto = Map(configuration);

            return configurationDto;
        }

        // TODO change with auto mapper
        private ConfigurationDto Map(Configuration configuration)
        {
            if (configuration == null)
                return null;

            return new ConfigurationDto
            {
                Key = configuration.Key,
                Group = configuration.Group,
                Value = configuration.Value
            };
        }

        public IEnumerable<ConfigurationDto> GetByGroup(string group)
        {
            if (string.IsNullOrEmpty(group))
                return null;

            var configurations = _configurationRepository.GetByGroup(group);
            var configurationDtos = Map(configurations);

            return configurationDtos;
        }
        // TODO change with auto mapper
        private IEnumerable<ConfigurationDto> Map(IEnumerable<Configuration> configurations)
        {
            return configurations.Select(Map);
        }


        public void Create(ConfigurationDto configurationDto)
        {
            if (configurationDto == null)
                return;


            var configuration = Map(configurationDto);

            _configurationRepository.Add(configuration);
        }

        // TODO change with auto mapper
        private Configuration Map(ConfigurationDto configurationDto)
        {
            if (configurationDto == null)
                return null;

            return new Configuration
            {
                Key = configurationDto.Key,
                Group = configurationDto.Group,
                Value = configurationDto.Value
            };
        }
    }
}
