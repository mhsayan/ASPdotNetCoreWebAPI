using Application.Operation.BusinessObjects;
using Application.Operation.Services;
using Autofac;
using AutoMapper;

namespace Application.Api.Models;

public class UpdateStudentModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public int Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    private ILifetimeScope _scope;
    private IStudentService _studentService { get; set; }
    private IMapper _mapper;

    public UpdateStudentModel()
    {
    }

    public UpdateStudentModel(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }

    public virtual void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
        _studentService = _scope.Resolve<IStudentService>();
        _mapper = _scope.Resolve<IMapper>();
    }

    public void UpdateStudent(Guid studentId)
    {
        var student = _mapper.Map<Student>(this);
        _studentService.UpdateStudent(studentId, student);
    }
}