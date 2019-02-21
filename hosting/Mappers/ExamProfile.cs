using Application.Dtos;
using AutoMapper;
using Presentation.ViewModels;

namespace hosting.Mappers
{
    // ReSharper disable once UnusedMember.Global
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<ExamDto, EnrolledExamViewModel>()
                .ForMember(dest => dest.StartDate, source => source.MapFrom(src => src.DateTime));
            CreateMap<Domain.Entities.Exam, ExamDto>();
        }
    }
}
