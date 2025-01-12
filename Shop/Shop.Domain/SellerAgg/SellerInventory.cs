using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {
        public SellerInventory(long productId, int count, int price, int? discountprecentage)
        {
            if(price < 1 || count < 1)
                throw new InvalidDomainDataException();
           
            ProductId = productId;
            Count = count;
            Price = price;
            Discountprecentage = discountprecentage;
        }

        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? Discountprecentage { get; private set; }

        public void Edit(int count, int price, int? discountprecentage)
        {
            if (price < 1 || count < 1)
                throw new InvalidDomainDataException();

            Count = count;
            Price = price;
            Discountprecentage = discountprecentage;
        }
    }
}

