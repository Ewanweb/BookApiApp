using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain;

namespace Shop.Application.Categories.AddChild
{
    public record AddChildCategoryCommand(long ParentId,string Title, string Slug, SeoData SeoData) : IBaseCommand;
}