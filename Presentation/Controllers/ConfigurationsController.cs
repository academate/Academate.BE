using Application.Dtos;
using Application.Services.AccessControl;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;
        private readonly IMapper _mapper;

        public ConfigurationsController(IConfigurationService configurationService,
            IMapper mapper)
        {
            _configurationService = configurationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get configuration by key.
        /// </summary>
        /// <param name="key">Configuration key</param>
        /// 
        [HttpGet("{key}")]
        public async Task<IActionResult> GetByKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                return BadRequest($"Invalid {nameof(key)}");

            var configurationDto = await _configurationService.GetByKey(key);
            var configurationViewModel = _mapper.Map<ConfigurationViewModel>(configurationDto);

            return Ok(configurationViewModel);
        }

        /// <summary>
        /// Get configurations by group.
        /// </summary>
        /// <param name="group">Configuration group</param>
        /// 
        [HttpGet("groups/{group}")]
        public async Task<IActionResult> GetByGroup(string group)
        {
            if (string.IsNullOrEmpty(group))
                return BadRequest($"Invalid {nameof(group)}");

            var configurationDtos = await _configurationService.GetByGroup(@group);
            var configurationViewModels = configurationDtos.Select(_mapper.Map<ConfigurationViewModel>); ;

            return Ok(configurationViewModels);
        }

        /// <summary>
        /// Create new configuration.
        /// </summary>
        /// <param name="configuration">the new configuration</param>
        /// 
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody]ConfigurationViewModel configuration)
        {
            var configurationDto = _mapper.Map<ConfigurationDto>(configuration);
            await _configurationService.Create(configurationDto);


            return Created("", null);
            //return CreatedAtAction(nameof(GetByKey), new { id = configuration.Key }, configuration);
        }
    }
}
