using Application.Dtos;
using AutoMapper;
using Domain.ValueObjects;
using Presentation.ViewModels;

namespace hosting.Mappers
{
    // ReSharper disable once UnusedMember.Global
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<ConfigurationDto, ConfigurationViewModel>();
            CreateMap<ConfigurationViewModel, ConfigurationDto>();

            CreateMap<ConfigurationDto, Configuration>();
            CreateMap<Configuration, ConfigurationDto>();
        }
    }
}
