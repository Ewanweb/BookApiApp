using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class OrderDiscount : ValueObject
    {
        public string DiscountTitle { get; private set; }
        public int DiscountAmount { get; private set; }
    }
}
