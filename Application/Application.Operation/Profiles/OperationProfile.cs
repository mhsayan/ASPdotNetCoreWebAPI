using EO = Application.Operation.Entities;
using BO = Application.Operation.BusinessObjects;
using AutoMapper;

namespace Application.Operation.Profiles;

public class OperationProfile : Profile
{
    public OperationProfile()
    {
        CreateMap<EO.Student, BO.Student>().ReverseMap();
    }
}