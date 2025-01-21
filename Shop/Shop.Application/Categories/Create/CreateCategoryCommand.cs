using Common.Application;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Create
{
    public record CreateCategoryCommand(string Title, string Slug, SeoData SeoData) : IBaseCommand;
}