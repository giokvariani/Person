using BasePerson.Application.Interfaces;
using BasePerson.Model.BusinessObjects;
using BasePerson.Persistence.DataLayer;

namespace BasePerson.Persistence.Repositories
{
    public class ConnectedPeopleRepository : Repository<ConnectedPeople>, IConnectedPeopleRepository
    {
        public ConnectedPeopleRepository(DataContext context) : base(context)
        {
        }
    }
}
