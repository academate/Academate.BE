using Application.Dtos;
using Application.Services.AccessControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationsController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        /// <summary>
        /// Get configuration by key.
        /// </summary>
        /// <param name="key">Configuration key</param>
        /// 
        [HttpGet("{key}")]
        public IActionResult GetByKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                return BadRequest($"Invalid {nameof(key)}");

            var configurationDto = _configurationService.GetByKey(key);
            var configurationViewModel = Map(configurationDto);

            return Ok(configurationViewModel);
        }

        private ConfigurationViewModel Map(ConfigurationDto configurationDto)
        {
            if (configurationDto == null)
                return null;

            return new ConfigurationViewModel
            {
                Key = configurationDto.Key,
                Group = configurationDto.Group,
                Value = configurationDto.Value
            };
        }

        /// <summary>
        /// Get configurations by group.
        /// </summary>
        /// <param name="group">Configuration group</param>
        /// 
        [HttpGet("groups/{group}")]
        public IActionResult GetByGroup(string group)
        {
            if (string.IsNullOrEmpty(group))
                return BadRequest($"Invalid {nameof(group)}");

            var configurationDtos = _configurationService.GetByGroup(group);
            var configurationViewModels = Map(configurationDtos);

            return Ok(configurationViewModels);
        }

        private IEnumerable<ConfigurationViewModel> Map(IEnumerable<ConfigurationDto> configurationDtos)
        {
            return configurationDtos.Select(Map);
        }

        /// <summary>
        /// Create new configuration.
        /// </summary>
        /// <param name="configuration">the new configuration</param>
        /// 
        [HttpPost("")]
        public IActionResult Create([FromBody]ConfigurationViewModel configuration)
        {
            var configurationDto = Map(configuration);
            _configurationService.Create(configurationDto);


            return Created("", null);
            //return CreatedAtAction(nameof(GetByKey), new { id = configuration.Key }, configuration);
        }

        private ConfigurationDto Map(ConfigurationViewModel configurationViewModel)
        {
            if (configurationViewModel == null)
                return null;

            return new ConfigurationDto
            {
                Key = configurationViewModel.Key,
                Group = configurationViewModel.Group,
                Value = configurationViewModel.Value
            };
        }
    }
}
