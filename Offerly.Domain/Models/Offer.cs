namespace Offerly.Domain.Models
{
    public class Offer
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public IEnumerable<OfferProduct> Products { get; set; }

        public decimal TotalAmount { get; set; }
    }
}