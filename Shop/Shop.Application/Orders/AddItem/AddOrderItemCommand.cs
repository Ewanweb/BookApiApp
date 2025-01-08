using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Orders.AddItem;

public record AddOrderItemCommand(long InventoryId, int count, long UserId) : IBaseCommand;
