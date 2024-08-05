using Happy_company.Model.Domain.Lookup;
using System.ComponentModel.DataAnnotations;

namespace Happy_company.Model.DTO
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Active status is required.")]
        public bool Active { get; set; } = false;

        [Required(ErrorMessage = "Role ID is required.")]
        public Guid RoleId { get; set; }
    }
}
