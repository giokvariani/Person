using BasePerson.Model.Enums;

namespace BasePerson.Model.BusinessObjects
{
    public class Phone2Person : BusinessObject
    {
        public Phone Phone { get; set; }
        public Person Person { get; set; }
        public PhoneType Type { get; set; }
    }
}
