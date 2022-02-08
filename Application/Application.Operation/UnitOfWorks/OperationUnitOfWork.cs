using Application.Data;
using Application.Operation.Contexts;
using Application.Operation.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Operation.UnitOfWorks;

public class OperationUnitOfWork : UnitOfWork, IOperationUnitOfWork
{
    public IStudentRepository Students { get; private set; }

    public OperationUnitOfWork(IOperationDbContext context,
        IStudentRepository students)
        : base((DbContext)context)
    {
        Students = students;
    }
}