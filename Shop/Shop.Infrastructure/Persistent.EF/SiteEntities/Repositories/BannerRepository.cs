using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.EF;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Repositories
{
    internal class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        private readonly ShopContext Context;
        public BannerRepository(ShopContext context) : base(context)
        {
            Context = context;
        }

        public void Delete(Banner banner)
        {
            Context.Banners.Remove(banner);
        }
    }
}