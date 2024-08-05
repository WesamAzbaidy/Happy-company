using System.ComponentModel.DataAnnotations;

namespace Happy_company.Model.DTO
{
    public class ChangeActiveStatusRequest
    {
        [Required(ErrorMessage = "Active status is required.")]
        public bool Active { get; set; }
    }
}
