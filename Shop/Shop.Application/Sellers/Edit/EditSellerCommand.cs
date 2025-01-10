using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand : IBaseCommand
    {
        public EditSellerCommand(long id, long userId, string shopName, string nationalCode)
        {
            Id = id;
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
        }
        public long Id { get; private set; }
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
    }
}
