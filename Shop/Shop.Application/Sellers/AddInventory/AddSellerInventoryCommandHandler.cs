using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInventory
{
    public class EditSellerInventoryCommandHandler : IBaseCommandHandler<EditSellerInventoryCommand>
    {
        private readonly ISellerRepository _repository;
        public async Task<OperationResult> Handle(EditSellerInventoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.SellerId);

            if (seller == null)
                return OperationResult.NotFound();

            var inventory = new SellerInventory(
                    request.ProductId, request.Count, request.Price, request.Discountprecentage
                );

            seller.AddInventory( inventory );
            await _repository.Save();

            return OperationResult.Success();


        }
    }
}
