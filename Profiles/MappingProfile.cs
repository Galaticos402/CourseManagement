using AutoMapper;
using CourseManagement.DTOs;
using CourseManagement.Models;

namespace CourseManagement.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }
    }
}
