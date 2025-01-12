using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.EditInventory
{
    public record EditSellerInventoryCommand : IBaseCommand
    {
        public EditSellerInventoryCommand(long sellerId, long inventoryId, int count, int price, int? discountprecentage)
        {
            SellerId = sellerId;
            InventoryId = inventoryId;
            Count = count;
            Price = price;
            Discountprecentage = discountprecentage;
        }

        public long SellerId { get; private set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? Discountprecentage { get; private set; }
    }
}
