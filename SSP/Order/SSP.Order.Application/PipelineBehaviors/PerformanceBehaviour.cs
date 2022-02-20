using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SSP.Order.Application.PipelineBehaviors
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        #region Variables
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public PerformanceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }
        #endregion

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();
            var elapsedMiliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMiliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;

                _logger.LogWarning("Long Running Request: {name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                    requestName, elapsedMiliseconds, request);
            }
            return response;
        }
    }
}
