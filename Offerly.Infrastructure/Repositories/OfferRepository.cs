using Microsoft.EntityFrameworkCore;
using Offerly.Domain.Contracts.Repositories;
using Offerly.Domain.Entities;
using Offerly.Domain.Models;
using Offerly.Infrastructure.Bootstrapping;

namespace Offerly.Infrastructure.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly OfferlyDbContext _dbContext;

        public OfferRepository(OfferlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveOffer(Offer offer)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                var offerEntity = new OfferEntity { Date = DateTime.Now, TotalAmount = offer.TotalAmount };
                _dbContext.Offers.Add(offerEntity);

                _dbContext.SaveChanges();

                foreach (var product in offer.Products)
                {
                    var offerDetail = new OfferDetailEntity()
                    {
                        OfferId = offerEntity.Id,
                        ProductId = product.Id,
                        ProductQuantity = product.Quantity
                    };
                    offerEntity.OfferDetails.Add(offerDetail);
                }

                _dbContext.SaveChanges();

                transaction.Commit();
            }
        }

        public void UpdateOffer(Offer offer)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                var dboOffer = _dbContext.Offers.SingleOrDefault(x => x.Id == offer.Id);

                if (dboOffer != null)
                {
                    _dbContext.OfferDetails.Where(x => x.OfferId == offer.Id).ExecuteDelete();

                    dboOffer.TotalAmount = offer.TotalAmount;
                    foreach (var product in offer.Products)
                    {
                        var offerDetail = new OfferDetailEntity()
                        {
                            OfferId = dboOffer.Id,
                            ProductId = product.Id,
                            ProductQuantity = product.Quantity
                        };
                        dboOffer.OfferDetails.Add(offerDetail);
                    }

                    _dbContext.SaveChanges();

                    transaction.Commit();
                }
            }
        }
    }
}