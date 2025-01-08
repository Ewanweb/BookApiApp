using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain.Repository;

namespace Shop.Domain.SellerAgg.Repository
{
    public interface ISellerRepository : IBaseRepository<Seller>
    {
        Task<InventoryResult> GetInventoryById(long id);
    }

    public class InventoryResult
    {
        public long Id { get; private set; }
        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
    }
}