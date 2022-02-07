using Application.Data;

namespace Application.Operation.BusinessObjects;

public class Student : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}