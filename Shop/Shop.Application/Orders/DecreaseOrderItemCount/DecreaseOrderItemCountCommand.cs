using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Orders.DecreaseOrderItemCount
{
    public record DecreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}