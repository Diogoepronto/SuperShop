using System.ComponentModel.DataAnnotations;

namespace SuperShop.Models
{
    public class CityViewModel
    {
        public int CountryId { get; set; }

        public int CityId { get; set; }

        [Required]
        [Display(Name = "City")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot contain more than {1} characters.")]
        public string Name { get; set; }

    }
}
