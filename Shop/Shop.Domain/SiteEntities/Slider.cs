using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SiteEntities
{
    public class Slider : BaseEntity
    {
        public Slider(string title, string link, string imageName)
        {
            Guard(title, link, imageName);
            Title = title;
            Link = link;
            ImageName = imageName;
        }

        public string Title { get; private set; }
        public string Link { get; private set; }
        public string ImageName { get; private set; }


        public void Edit(string title, string link, string imageName)
        {
            Guard(title, link, imageName);
            Title = title;
            Link = link;
            ImageName = imageName;
        }

        private void Guard(string title, string link, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));

        }
    }
}