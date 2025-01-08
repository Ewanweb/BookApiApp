using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandHandler  : IBaseCommandHandler<AddOrderItemCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly ISellerRepository _sellerRepository;

        public AddOrderItemCommandHandler(IOrderRepository repository, ISellerRepository sellerRepository)
        {
            _repository = repository;
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
            
            if(inventory == null)
                return OperationResult.NotFound();
            
            if(inventory.Count < request.count)
                return OperationResult.Error("تعداد محصولات درخواستی بیشتر از محصولات موجود است");

            var order = await _repository.GetCurrentUserOrder(request.UserId);

            if(order == null)
                order = new Order(request.UserId);
            
            order.AddItem(new OrderItem(request.InventoryId, request.count, inventory.Price));

            if(ItemCountBiggerThanInventoryCount(inventory, order))
                return OperationResult.Error("تعداد محصولات درخواستی بیشتر از محصولات موجود است");

            await _repository.Save();
            return OperationResult.Success();
        }

        private bool ItemCountBiggerThanInventoryCount(InventoryResult inventory, Order order)
        {
            var OrderItem = order.Items.First(f => f.InventoryId == inventory.Id);

            if(OrderItem.Count > inventory.Count)
                return true;

            return false;
        }
    }
