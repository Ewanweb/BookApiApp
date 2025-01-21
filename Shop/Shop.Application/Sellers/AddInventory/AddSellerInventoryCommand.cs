using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.AddInventory
{
    public record EditSellerInventoryCommand : IBaseCommand
    {
        public EditSellerInventoryCommand(long sellerId, long productId, int count, int price, int? discountprecentage)
        {
            SellerId = sellerId;
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
    }
}
