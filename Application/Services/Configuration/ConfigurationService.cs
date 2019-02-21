using Application.Dtos;
using Application.Services.AccessControl;
using AutoMapper;
using Repository.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;

        public ConfigurationService(IConfigurationRepository configurationRepository,
            IMapper mapper)
        {
            _configurationRepository = configurationRepository;
            _mapper = mapper;
        }

        public async Task<ConfigurationDto> GetByKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;

            var configuration = await _configurationRepository.GetByKey(key);
            var configurationDto = _mapper.Map<ConfigurationDto>(configuration);

            return configurationDto;
        }

        public async Task<IEnumerable<ConfigurationDto>> GetByGroup(string @group)
        {
            if (string.IsNullOrEmpty(group))
                return null;

            var configurations = await _configurationRepository.GetByGroup(@group);
            var configurationDtos = configurations.Select(_mapper.Map<ConfigurationDto>);

            return configurationDtos;
        }


        public async Task Create(ConfigurationDto configurationDto)
        {
            if (configurationDto == null)
                return;

            var configuration = _mapper.Map<Domain.ValueObjects.Configuration>(configurationDto);

            await _configurationRepository.Add(configuration);
        }
    }
}
