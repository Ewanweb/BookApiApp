using Common.Query;
using Shop.Domain.OrderAgg.Enums;

namespace Shop.Query.Orders.DTOs;

public class OrderFilterDataDto : BaseDto
{
    public long UserId { get; private set; }
    public string UserFullName { get; private set; }
    public OrderStatus Status { get; private set; }
    public string Shire { get; private set; }
    public int TotalPrice { get; private set; }
    public int TotalItemCount { get; private set; }
    public string ShipingType { get; private set; }
}