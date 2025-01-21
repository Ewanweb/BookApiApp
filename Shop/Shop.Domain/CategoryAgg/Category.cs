using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Shop.Domain.CategoryAgg.Service;

namespace Shop.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public long? ParentId { get; private set; }
        public List<Category> Childs { get; private set; }


        public Category(string title, string slug, SeoData seoData, ICategoryDomainService categoryDomainService)
        {
            slug = slug.ToSlug();
            Guard(title, slug, categoryDomainService);
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }


        public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService categoryDomainService)
        {
            slug = Slug.ToSlug();
            Guard(title,  slug, categoryDomainService);
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService categoryDomainService)
        {
            Childs.Add(new Category(title, slug, seoData, categoryDomainService)
            {
                ParentId = Id,
            });
        }

        private void Guard(string title, string slug, ICategoryDomainService categoryDomainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if(slug != Slug)
                if(categoryDomainService.IsExist(slug))
                    throw new SlugIsDuplicateException();
        }
    }
}