using Application.Dtos;
using AutoMapper;
using Presentation.ViewModels;

namespace hosting.Mappers.Configurations
{
    // ReSharper disable once UnusedMember.Global
    public class AcademicUnitProfile : Profile
    {
        public AcademicUnitProfile()
        {
            CreateMap<AcademicUnitDto, AcademicUnitViewModel>()
                .ForMember(dest => dest.Lecturer,
                            source => source.MapFrom(src => src.Lecturer != null ? src.Lecturer.FullName : null));
            CreateMap<Domain.Entities.AcademicUnit, AcademicUnitDto>();
        }
    }
}
