using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Orders.RemoveItem;
    public record RemoveOrderItemCommand(long UserId, long ItemId) : IBaseCommand;
