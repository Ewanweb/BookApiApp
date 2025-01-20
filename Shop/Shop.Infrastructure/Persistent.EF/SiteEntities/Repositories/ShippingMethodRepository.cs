using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.EF;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Repositories;

internal class ShippingMethodRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
{
    private readonly ShopContext Context;
    public ShippingMethodRepository(ShopContext context) : base(context)
    {
        Context = context;
    }

    public void Delete(ShippingMethod slider)
    {
        Context.ShippingMethods.Remove(slider);
    }
}