using System.ComponentModel.DataAnnotations;

namespace Happy_company.Model.DTO
{
    public class ItemRequest
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Maxummum Length 20")]
        [MinLength(3, ErrorMessage = "Minnimum Length 3")]
        public string Name { get; set; }
        public string? SKUCode { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int QTY { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "larger 0.")]
        public decimal CostPrice { get; set; }
        public decimal? MSRPPrice { get; set; }
        [Required]
        public Guid WarehouseId { get; set; }
    }
}
