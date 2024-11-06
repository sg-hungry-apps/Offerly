using Offerly.Domain.Models;

namespace Offerly.Domain.Contracts.Queries
{
    public interface IOfferQuery
    {
        IEnumerable<Offer> GetOffers(int pageNumber = 1, int pageSize = 3);

        Offer? GetOffer(int offerId);
    }
}