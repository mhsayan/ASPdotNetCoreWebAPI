using Application.Operation.BusinessObjects;
using Application.Operation.Services;
using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.Api.Models;

public class GetStudentModel
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

    public GetStudentModel()
    {
    }

    public GetStudentModel(IStudentService studentService, IMapper mapper)
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

    public void GetStudent(Guid studentId)
    {
        var student = _studentService.GetStudent(studentId);

        _mapper.Map(student, this);
    }
}