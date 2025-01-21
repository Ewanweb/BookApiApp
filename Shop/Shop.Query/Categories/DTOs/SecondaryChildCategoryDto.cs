using Common.Domain;
using Common.Query;

namespace Shop.Query.Categories.DTOs;

public class SecondaryChildCategoryDto :BaseDto
{
    public long? ParentId { get;  set; }
    public string Title { get;  set; }
    public string Slug { get;  set; }
    public SeoData SeoData { get;  set; }
}