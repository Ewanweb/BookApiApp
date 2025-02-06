using Common.Query.Filters;
using Shop.Domain.OrderAgg.Enums;

namespace Shop.Query.Orders.DTOs;

public class OrderFilterParams : BaseFilterParam
{
    public long? UserId { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public OrderStatus? Status { get; private set; }
}