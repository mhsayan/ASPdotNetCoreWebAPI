using BO = Application.Operation.BusinessObjects;

namespace Application.Operation.Services;

public interface IStudentService
{
    void Create(BO.Student student);
}