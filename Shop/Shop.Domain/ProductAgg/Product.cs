using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SecondorySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specification { get; private set; }


        private Product()
        {
            
        }
        public Product(string title, string imageName, string description, long categoryId, long secondorySubCategoryId,
         string slug, SeoData seoData, IProductDomainService productDomainService)
        {
            Guard(title,imageName,description,slug,productDomainService);

            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SecondorySubCategoryId = secondorySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }


        public void Edit(string title, string imageName, string description, long categoryId, long secondorySubCategoryId,
         string slug, SeoData seoData, IProductDomainService productDomainService)
        {
            Guard(title,imageName,description,slug,productDomainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SecondorySubCategoryId = secondorySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }


        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }

        public void RemoveImage(long id)
        {
            var image = Images.FirstOrDefault(f => f.Id == id);

            if(image == null)
                return;

            Images.Remove(image);
        }

        public void SetSpecification(List<ProductSpecification> specification)
        {
            specification.ForEach(s => s.ProductId = Id);
            Specification = specification;
        }

        public void Guard(string title, string imageName,string slug,string description, IProductDomainService productDomainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if(slug != Slug)
            {
                if(productDomainService.SlugIsExist(slug))
                    throw new SlugIsDuplicateException();
            }
        }
    }
}