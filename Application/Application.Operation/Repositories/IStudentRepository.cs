using Application.Data;
using Application.Operation.Entities;

namespace Application.Operation.Repositories
{
    public interface IStudentRepository : IRepository<Student, Guid>
    {
    }
}
