using Application.Operation.UnitOfWorks;
using AutoMapper;
using BO = Application.Operation.BusinessObjects;
using EO = Application.Operation.Entities;

namespace Application.Operation.Services;

public class StudentService : IStudentService
{
    private readonly IOperationUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public StudentService(IOperationUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void Create(BO.Student student)
    {
        var studentEntity = _mapper.Map<EO.Student>(student);

        _unitOfWork.Students.Add(studentEntity);
        _unitOfWork.Save();
    }
}