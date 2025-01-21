using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories;

internal static class CategoryMaper
{
    public static CategoryDto Map(this Category? category)
    {
        if (category is null)
            return null;
        
        return new CategoryDto()
        {
            Id = category.Id,
            Title = category.Title,
            Slug = category.Slug,
            SeoData = category.SeoData,
            CreationDate = category.CreationDate,
            Childs = category.Childs.MapChild()
        };
    }
    
    public static List<CategoryDto> Map(this List<Category> categories)
    {
        var model = new List<CategoryDto>();
        
        categories.ForEach(category =>
            model.Add(new CategoryDto()
        {
            Id = category.Id,
            Title = category.Title,
            Slug = category.Slug,
            SeoData = category.SeoData,
            CreationDate = category.CreationDate,
            Childs = category.Childs.MapChild()
        }));
        
        return model;
    }
    

    public static List<ChildCategoryDto> MapChild(this List<Category> children)
    {
        var model = new List<ChildCategoryDto>();
        children.ForEach(c =>
            model.Add(new ChildCategoryDto()
            {
                Id = c.Id,
                Title = c.Title,
                Slug = c.Slug,
                SeoData = c.SeoData,
                CreationDate = c.CreationDate,
                ParentId = (long)c.ParentId,
                Childs = c.Childs.MapSecondaryChild()
            }));
        return model;
    }
    
    private static List<SecondaryChildCategoryDto> MapSecondaryChild(this List<Category> children)
    {
        var model = new List<SecondaryChildCategoryDto>();
        children.ForEach(c =>
            model.Add(new SecondaryChildCategoryDto()
            {
                Id = c.Id,
                Title = c.Title,
                Slug = c.Slug,
                SeoData = c.SeoData,
                CreationDate = c.CreationDate,
                ParentId = (long)c.ParentId,
            }));
        return model;
    }


}