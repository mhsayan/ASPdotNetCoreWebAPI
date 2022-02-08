using Application.Api.Models;
using Application.Operation.BusinessObjects;
using AutoMapper;

namespace Application.Api.Profiles;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<CreateStudentModel, Student>().ReverseMap();
        CreateMap<GetStudentModel, Student>().ReverseMap();
        CreateMap<UpdateStudentModel, Student>().ReverseMap();
    }
}