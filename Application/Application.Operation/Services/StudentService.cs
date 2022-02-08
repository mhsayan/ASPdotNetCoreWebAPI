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

    public BO.Student GetStudent(Guid studentId)
    {
        var studentEntity = _unitOfWork.Students.GetById(studentId);

        return _mapper.Map<BO.Student>(studentEntity);
    }

    public void UpdateStudent(Guid studentId, BO.Student student)
    {
        var studentEntity = _unitOfWork.Students.GetById(studentId);

        if (studentEntity != null)
        {
            _mapper.Map(student, studentEntity);
            _unitOfWork.Save();
        }
        else
            throw new InvalidOperationException("Couldn't find student");
    }

    public void DeleteStudent(Guid studentId)
    {
        _unitOfWork.Students.Remove(studentId);
        _unitOfWork.Save();
    }
}