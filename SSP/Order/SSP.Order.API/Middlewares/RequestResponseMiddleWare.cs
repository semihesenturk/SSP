using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SSP.Order.API.Middlewares
{
    public class RequestResponseMiddleWare
    {
        #region Variables
        private readonly RequestDelegate next;
        private readonly ILogger<RequestResponseMiddleWare> logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        #endregion

        #region Constructor
        public RequestResponseMiddleWare(RequestDelegate Next, ILogger<RequestResponseMiddleWare> _logger)
        {
            next = Next;
            logger = _logger;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }
        #endregion

        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;

            stream.Seek(0, SeekOrigin.Begin);

            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);

            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;

            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                                                   0,
                                                   readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);

            } while (readChunkLength > 0);

            return textWriter.ToString();
        }

        private async Task<String> getRequestBody(HttpContext context)
        {
            context.Request.EnableBuffering();

            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);

            String reqBody = ReadStreamInChunks(requestStream);

            context.Request.Body.Position = 0;

            return reqBody;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //request
            String requestText = await getRequestBody(httpContext);

            //response part1
            var originalBodyStream = httpContext.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            httpContext.Response.Body = responseBody;

            await next.Invoke(httpContext);

            //response.part2
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            String responseText = await new StreamReader(httpContext.Response.Body, Encoding.UTF8).ReadToEndAsync();
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

            await responseBody.CopyToAsync(originalBodyStream);

            logger.LogInformation($"Request: {requestText}");
            logger.LogInformation($"Response: {responseText}");
        }
    }
}
