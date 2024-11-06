namespace Offerly.Domain.Entities;

public partial class ProductEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<OfferDetailEntity> OfferDetails { get; set; } = new List<OfferDetailEntity>();
}