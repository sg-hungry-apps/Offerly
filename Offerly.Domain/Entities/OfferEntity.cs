namespace Offerly.Domain.Entities;

public partial class OfferEntity
{
    public int Id { get; set; } 

    public DateTime Date { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual ICollection<OfferDetailEntity> OfferDetails { get; set; } = new List<OfferDetailEntity>();
}