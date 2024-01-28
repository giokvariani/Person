using BasePerson.Application.Interfaces;
using BasePerson.Model.BusinessObjects;
using BasePerson.Persistence.DataLayer;

namespace BasePerson.Persistence.Repositories
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(DataContext context) : base(context)
        {
        }

        public async Task<Phone?> ReadAsync(string number)
        {
            var phone = (await ReadAsync(x => x.Number == number)).SingleOrDefault();
            return phone;
        }
    }
}
