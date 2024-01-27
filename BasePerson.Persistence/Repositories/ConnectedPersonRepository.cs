using BasePerson.Application.Interfaces;
using BasePerson.Model.BusinessObjects;
using BasePerson.Persistence.DataLayer;

namespace BasePerson.Persistence.Repositories
{
    public class ConnectedPersonRepository : Repository<ConnectedPerson>, IConnectedPersonRepository
    {
        public ConnectedPersonRepository(DataContext context) : base(context)
        {
        }
    }
}
