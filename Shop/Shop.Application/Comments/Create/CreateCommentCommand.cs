using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Comments.Create
{
    public record CreateCommentCommand(string Text, long UserId, long ProductId) : IBaseCommand;
}