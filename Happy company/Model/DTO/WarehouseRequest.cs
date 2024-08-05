using System.ComponentModel.DataAnnotations;

namespace Happy_company.Model.DTO
{
    public class WarehouseRequest
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Maxummum Length 20")]
        [MinLength(3, ErrorMessage = "Minnimum Length 3")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Maxummum Length 100")]
        [MinLength(5, ErrorMessage = "Minnimum Length 5")]
        public string Address { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Maxummum Length 10")]
        [MinLength(3, ErrorMessage = "Minnimum Length 3")]
        public string City { get; set; }
        [Required]
        public Guid CountryID { get; set; }
    }
}
