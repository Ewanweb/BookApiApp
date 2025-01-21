using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.EF;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList;

public record GetCategoryListQuery : IBaseQuery<List<CategoryDto>>;

internal class GetCategoryListQueryHandler : IBaseQueryHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly ShopContext _context;

    public GetCategoryListQueryHandler(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories.OrderBy(d => d.Id).ToListAsync(cancellationToken);
        return model.Map();
    }
}