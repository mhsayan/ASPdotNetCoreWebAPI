using Application.Operation.Services;
using Autofac;
using AutoMapper;

namespace Application.Api.Models;

public class CreateStudentModel
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public int Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    private ILifetimeScope _scope;
    private IStudentService _studentService { get; set; }
    private IMapper _mapper;
    
    public CreateStudentModel()
    {
    }

    public virtual void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
        _studentService = _scope.Resolve<IStudentService>();
        _mapper = _scope.Resolve<IMapper>();
    }

    public CreateStudentModel(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }

    
}