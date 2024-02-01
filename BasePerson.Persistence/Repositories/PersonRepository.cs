using BasePerson.Application.Exceptions;
using BasePerson.Application.Interfaces;
using BasePerson.Model.BusinessObjects;
using BasePerson.Persistence.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
        public override async Task<IEnumerable<Person>> ReadAsync(Expression<Func<Person, bool>> predicate)
        {
            var quarable = base.ReadCustom(predicate);
            var persons = await quarable.Include(x => x.City).ToListAsync();
            return persons;
        }
        public override async Task<Person> ReadAsync(int id)
        {
            var queryable = base.ReadCustom(x => x.Id == id);
            var person =(await queryable.Include(x => x.City).SingleOrDefaultAsync())!;
            return person;
        }
    }
}
