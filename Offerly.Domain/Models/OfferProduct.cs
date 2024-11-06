namespace Offerly.Domain.Models
{
    //TODO SG better name for this?
    public class OfferProduct
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}