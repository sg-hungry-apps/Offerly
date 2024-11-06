using Microsoft.EntityFrameworkCore;
using Offerly.Domain.Contracts.Queries;
using Offerly.Domain.Extensions;
using Offerly.Domain.Models;
using Offerly.Infrastructure.Bootstrapping;

namespace Offerly.Infrastructure.Queries
{
    public class OfferQuery : IOfferQuery
    {
        private readonly OfferlyDbContext _dbContext;

        public OfferQuery(OfferlyDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public IEnumerable<Offer> GetOffers(int pageNumber = 1, int pageSize = 3)
        {
            var response = new List<Offer>();

            var dboOffers = _dbContext.Offers.Include(o => o.OfferDetails).ThenInclude(p => p.Product).OrderBy(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            foreach (var dbOffer in dboOffers)
            {
                var offer = dbOffer.ToOffer();
                response.Add(offer);
            }

            return response;
        }

        public Offer? GetOffer(int offerId)
        {
            var dboOffer = _dbContext.Offers.Include(o => o.OfferDetails).ThenInclude(p => p.Product).FirstOrDefault(x => x.Id == offerId);

            return dboOffer == null
                ? null
                : dboOffer.ToOffer();
        }
    }
}