using Offerly.Domain.Models;

namespace Offerly.Domain.Contracts.Repositories
{
    public interface IOfferRepository
    {
        void SaveOffer(Offer offer);

        void UpdateOffer(Offer offer);
    }
}