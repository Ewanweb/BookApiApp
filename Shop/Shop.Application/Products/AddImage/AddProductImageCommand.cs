using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.AddImage
{
    public record AddProductImageCommand : IBaseCommand
    {
        public AddProductImageCommand(IFormFile imageFile, long productId, int sequence)
        {
            ImageFile = imageFile;
            ProductId = productId;
            Sequence = sequence;
        }

        public IFormFile ImageFile { get; private set; }
        public long ProductId { get; private set; }
        public int Sequence { get; private set; }

    }
}