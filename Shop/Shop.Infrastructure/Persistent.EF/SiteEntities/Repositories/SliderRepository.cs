using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.EF;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Repositories;

internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
{
    private readonly ShopContext Context;
    public SliderRepository(ShopContext context) : base(context)
    {
        Context = context;
    }

    public void Delete(Slider slider)
    {
        Context.Sliders.Remove(slider);
    }
}