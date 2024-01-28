using BasePerson.Model.BusinessObjects;

namespace BasePerson.Application.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person?> ReadAsync(string IdNumber);
    }
}
