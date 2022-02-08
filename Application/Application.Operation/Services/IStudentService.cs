using BO = Application.Operation.BusinessObjects;

namespace Application.Operation.Services;

public interface IStudentService
{
    void Create(BO.Student student);
    BO.Student GetStudent(Guid studentId);
    void UpdateStudent(Guid studentId, BO.Student student);
}