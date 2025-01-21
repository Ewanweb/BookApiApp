using Microsoft.EntityFrameworkCore;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.EF;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ShopContext Context;
        public OrderRepository(ShopContext context) : base(context)
        {
            Context = context;
        }
        public async Task<Order?> GetCurrentUserOrder(long userId)
        {
            return await Context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId
            && f.Status == OrderStatus.Pending);
        }

       
    }
}