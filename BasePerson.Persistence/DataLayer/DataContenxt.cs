using BasePerson.Model.BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace BasePerson.Persistence.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Phone2Person> Phone2People { get; set; }
        public DbSet<ConnectedPerson> ConnectedPeople { get; set; }
    }
}
