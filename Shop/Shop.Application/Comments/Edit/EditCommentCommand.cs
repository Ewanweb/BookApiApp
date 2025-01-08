using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain;

namespace Shop.Application.Categories.Edit
{
    public record EditCommentCommand(long CommentId,string Text, long UserId) : IBaseCommand;
}