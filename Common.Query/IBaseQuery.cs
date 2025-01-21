using MediatR;

namespace Common.Query;

public interface IBaseQuery<TResponse> : IRequest<TResponse> where TResponse : class
{
    
}