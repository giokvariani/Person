using BasePerson.Model.Enums;

namespace BasePerson.Model.BusinessObjects
{
    public class Phone : BusinessObject
    {
        public string Number { get; set; }
        public PhoneType Type { get; set; }
    }
}
