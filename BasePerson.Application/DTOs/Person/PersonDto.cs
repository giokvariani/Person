using BasePerson.Application.Attributes;
using BasePerson.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace BasePerson.Application.DTOs.Person
{
    public class PersonDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [ValidateLanguage(ErrorMessage = "Only English or Georgian letters are allowed.")]
        public string FirstName { get; set; }

        [Required]
        [ValidateLanguage(ErrorMessage = "Only English or Georgian letters are allowed.")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "The property must be exactly 11 characters long.")]
        public string IDNumber { get; set; }
        [Required]
        [MinimumAge(18)]
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public int CityId { get; set; }
    }
}
