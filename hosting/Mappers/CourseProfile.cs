﻿using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels;

namespace hosting.Mappers
{
    // ReSharper disable once UnusedMember.Global
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();

            CreateMap<Enrollment, UserCourseDto>()
                .ForMember(dest => dest.EnrollmentId,
                    source => source.MapFrom(src => src.Id));

            CreateMap<UserCourseDto, UserCourseViewModel>();

        }
    }
}
