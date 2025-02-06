using Common.Query;

namespace Shop.Query.Orders.DTOs;

public class OrderItenDto : BaseDto
{
    public long OrderId { get; internal set; }
    public long InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int TotalPrice => Price * Count;
}