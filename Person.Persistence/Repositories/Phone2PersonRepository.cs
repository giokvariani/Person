using BasePerson.Application.Interfaces;
using BasePerson.Model.BusinessObjects;
using BasePerson.Persistence.DataLayer;

namespace BasePerson.Persistence.Repositories
{
    public class Phone2PersonRepository : Repository<Phone2Person>, IPhone2PersonRepository
    {
        public Phone2PersonRepository(DataContext context) : base(context)
        {
        }
    }
}
