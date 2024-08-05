using Happy_company.Model.Domain.Lookup;

namespace Happy_company.Model.DTO
{
    public class WarehouseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public Guid CountryID { get; set; }
    }
}
