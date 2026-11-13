

namespace ThanhCometics.Data.ViewModels
{
    public class VoucherViewModel
    {
        public int VoucherId { get; set; }

        public string VoucherName { get; set; } = null!;

        public string VoucherCode { get; set; } = null!;

        public string? Description { get; set; }

        public decimal DiscountAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public bool? Status { get; set; }

        public decimal? MinimumPurchase { get; set; }
    }
}
