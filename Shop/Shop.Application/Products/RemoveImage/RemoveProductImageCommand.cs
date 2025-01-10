using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.RemoveImage
{
    public record RemoveProductImageCommand(long ProductId, long ImageId) : IBaseCommand;


}