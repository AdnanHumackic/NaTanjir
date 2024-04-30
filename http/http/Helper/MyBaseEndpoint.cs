using Microsoft.AspNetCore.Mvc;

namespace http.Helper
{
    public abstract class MyBaseEndpoint<TRequest, TResponse> : ControllerBase
    {
        public abstract Task<TResponse> Akcija(TRequest request, CancellationToken cancellationToken);

    }
}
