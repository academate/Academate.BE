using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels;
using System;

namespace hosting.Mappers
{
    // ReSharper disable once UnusedMember.Global
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {

            CreateMap<Enrollment, EnrollmentDto>()
                .ForMember(dest => dest.Title,
                    source => source.MapFrom(src => src.Course != null ? src.Course.Title : String.Empty))
                .ForMember(dest => dest.Status,
                source => source.MapFrom(src => src.Status.ToString()));

            CreateMap<SubmittedTask, SubmittedTaskDto>();

            CreateMap<EnrollmentDto, EnrollmentViewModel>();

            CreateMap<SubmittedTaskDto, SubmittedTaskViewModel>();
        }
    }
}
