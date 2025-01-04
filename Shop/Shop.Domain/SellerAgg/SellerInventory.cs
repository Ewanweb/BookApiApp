using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {
        public SellerInventory(long sellerId, long productId, int count, int price)
        {
            if(price < 1 || count < 1)
                throw new InvalidDomainDataException();
           
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
        }

        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
    }
}

