using MediatR;
using Offerly.Application.CommandResponses;
using Offerly.Application.Commands;
using Offerly.Application.Dtos;
using Offerly.Application.Extensions;
using Offerly.Domain.Contracts.Queries;
using Offerly.Domain.Contracts.Repositories;
using Offerly.Domain.Extensions;
using Offerly.Domain.Models;

namespace Offerly.Application.CommandHandlers
{
    public class SaveOfferCommandHandler : IRequestHandler<SaveOfferCommand, CommandResponse>
    {
        private readonly IProductQuery _productQuery;
        private readonly IOfferRepository _offerRepository;

        private List<OfferProduct> _offerProducts { get; set; } = new List<OfferProduct>();

        public SaveOfferCommandHandler(IProductQuery productQuery, IOfferRepository offerRepository)
        {
            _productQuery = productQuery;
            _offerRepository = offerRepository;
        }

        public Task<CommandResponse> Handle(SaveOfferCommand command, CancellationToken cancellationToken)
        {
            var (isValid, errorMessages) = ValidateOffer(command.Products);
            if (isValid == false)
            {
                return CommandResponse.ValidationErrorResponse(errorMessages);
            }

            var offer = _offerProducts.ToOffer();

            _offerRepository.SaveOffer(offer);

            return CommandResponse.SuccessfulResponse();
        }

        //TODO SG separate class for validation
        private (bool IsValid, List<string> ErrorMessages) ValidateOffer(IEnumerable<OfferProductDto> products)
        {
            var isValid = true;
            var errorMessages = new List<string>();

            if (products == null || products.Count() == 0)
            {
                isValid = false;
                errorMessages.Add("There must be at least one product in the request.");
            }
            else
            {
                if (products.DuplicateExists())
                {
                    isValid = false;
                    errorMessages.Add("There are duplicate products in the request.");
                }
                else
                {
                    //TODO SG should we do this even if duplicate exists?
                    isValid = ValidateProducts(products, isValid, errorMessages);
                }
            }

            return (isValid, errorMessages);
        }

        //TODO SG separate class for validation
        private bool ValidateProducts(IEnumerable<OfferProductDto> products, bool isValid, List<string> errorMessages)
        {
            var dboProducts = _productQuery.GetProducts(products.Select(x => x.Id)).Distinct().ToList();

            foreach (var product in products)
            {
                var dboProduct = dboProducts.SingleOrDefault(x => x.Id == product.Id);

                isValid = ValidateProduct(errorMessages, dboProduct, product);

                if (isValid)
                {
                    _offerProducts.Add(new OfferProduct
                    {
                        Id = dboProduct.Id,
                        Name = dboProduct.Name,
                        Price = dboProduct.Price,
                        Quantity = product.Quantity,
                    });
                }
            }

            return isValid;
        }

        //TODO SG separate class for validation
        private static bool ValidateProduct(List<string> errorMessages, Product? dboProduct, OfferProductDto product)
        {
            var isValidProduct = true;

            if (product != null)
            {
                //TODO SG should this be BadRequest or UnprocessableContent
                if (dboProduct == null)
                {
                    isValidProduct = false;
                    errorMessages.Add($"Product {product.Id} does not exist.");
                }

                if (product.Quantity <= 0)
                {
                    isValidProduct = false;
                    errorMessages.Add($"Product {product.Id} must have a quantity over 0.");
                }
            }

            return isValidProduct;
        }
    } 
}