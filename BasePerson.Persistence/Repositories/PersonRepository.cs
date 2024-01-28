using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using BasePerson.Model.BusinessObjects;
using BasePerson.Persistence.DataLayer;

namespace BasePerson.Persistence.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context)
        {
        }

        public async Task<Person?> ReadAsync(string idNumber)
        {
            var person = (await ReadAsync(x => x.IDNumber == idNumber)).SingleOrDefault();
            return person;
        }
    }
}
