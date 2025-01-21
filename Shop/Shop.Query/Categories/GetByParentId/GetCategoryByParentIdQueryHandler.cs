using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.EF;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId;

internal class GetCategoryByParentIdQueryHandler : IBaseQueryHandler<GetCategoryByParentIdQuery, List<ChildCategoryDto>>
{
    private readonly ShopContext _context;

    public GetCategoryByParentIdQueryHandler(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
    {
        var resualt = await _context.Categories.Where(r => r.ParentId == request.ParentId).ToListAsync(cancellationToken);
        return resualt.MapChild();
    }
}