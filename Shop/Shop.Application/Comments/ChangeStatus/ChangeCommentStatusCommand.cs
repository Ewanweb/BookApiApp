using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.Create
{
    public record ChangeCommentStatusCommand(long Id, CommentStatus Status) : IBaseCommand;
}