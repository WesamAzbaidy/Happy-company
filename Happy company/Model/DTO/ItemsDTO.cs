namespace Happy_company.Model.DTO
{
    public class ItemsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string? SKUCode { get; set; }

        public int QTY { get; set; }
        public decimal CostPrice { get; set; }

        public decimal? MSRPPrice { get; set; }

        public Guid WarehouseId { get; set; }
    }
}
