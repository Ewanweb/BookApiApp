using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.Edit
{
    public record EditProductCommand : IBaseCommand
    {
        public EditProductCommand(long productId, string title, IFormFile imageFile, string description, long categoryId, long subCategoryId, long secondorySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> specification)
        {
            ProductId = productId;
            Title = title;
            ImageFile = imageFile;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondorySubCategoryId = secondorySubCategoryId;
            Slug = slug;
            SeoData = seoData;
            Specification = specification;
        }
        public long ProductId { get; private set; }
        public string Title { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondorySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string, string> Specification { get; private set; }
    }

}