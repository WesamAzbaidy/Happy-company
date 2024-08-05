using Happy_company.Model.Domain.Lookup;
using System.Diagnostics.Metrics;

namespace Happy_company.Model.Domain
{
    public class Warehouse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Guid CountryID { get; set; }
        public Country Country { get; set; }
    }
}
