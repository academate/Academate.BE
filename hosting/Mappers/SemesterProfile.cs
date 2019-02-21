using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace hosting.Mappers
{
    // ReSharper disable once UnusedMember.Global
    public class SemesterProfile : Profile
    {
        public SemesterProfile()
        {
            CreateMap<Semester, SemesterDto>();
            CreateMap<SemesterDto, Semester>();
        }
    }
}
