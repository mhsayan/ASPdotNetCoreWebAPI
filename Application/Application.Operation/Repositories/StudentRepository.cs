using Application.Data;
using Application.Operation.Contexts;
using Application.Operation.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Operation.Repositories
{
    public class StudentRepository : Repository<Student, Guid>,
        IStudentRepository
    {
        public StudentRepository(IOperationDbContext context)
            : base((DbContext)context)
        {
        }
    }
}
