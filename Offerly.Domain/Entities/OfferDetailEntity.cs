namespace Offerly.Domain.Entities;

public partial class OfferDetailEntity
{
    public int Id { get; set; }

    public int OfferId { get; set; }

    public int ProductId { get; set; }

    public int ProductQuantity { get; set; }

    public virtual OfferEntity Offer { get; set; } = null!;

    public virtual ProductEntity Product { get; set; } = null!;
}