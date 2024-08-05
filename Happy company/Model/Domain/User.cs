using Happy_company.Model.Domain.Lookup;

namespace Happy_company.Model.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
