using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SiteEntities
{
    public class Banner : BaseEntity
    {
        public Banner(string link, string imageName, BannerPosition position)
        {
            Guard(link, imageName);
            Link = link;
            ImageName = imageName;
            Position = position;
        }

        public string Link { get; private set; }
        public string ImageName { get; private set; }
        public BannerPosition Position { get; private set; }


        public void Edit(string link, string imageName, BannerPosition position)
        {
            Guard(link, imageName);
            Link = link;
            ImageName = imageName;
            Position = position;
        }

        private void Guard(string link, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));

        }

    }

    public enum BannerPosition
    {

    }
}