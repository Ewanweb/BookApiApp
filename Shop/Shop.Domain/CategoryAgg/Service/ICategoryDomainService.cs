using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.CategoryAgg.Service
{
    public interface ICategoryDomainService
    {
        public bool IsExist(string slug);
    }
}