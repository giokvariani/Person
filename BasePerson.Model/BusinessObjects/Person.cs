using BasePerson.Model.Enums;

namespace BasePerson.Model.BusinessObjects
{
    public class Person : BusinessObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<Phone2Person> Phones { get; set; }
        public IEnumerable<ConnectedPerson> ConnectedPeople { get; set; }
        public string Image { get; set; }
    }
}
