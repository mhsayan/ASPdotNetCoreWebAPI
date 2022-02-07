using Application.Data;
using Application.Operation.Repositories;

namespace Application.Operation.UnitOfWorks
{
    public interface IOperationUnitOfWork : IUnitOfWork
    {
        IStudentRepository Students { get; }
    }
}