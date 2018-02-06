using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ServerManage.Filters
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly IHostingEnvironment _env;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
            context.Exception,
            context.Exception.Message);

            var json = new ErrorResponse("未知错误,请重试");

            if (_env.IsDevelopment()) json.DeveloperMessage = context.Exception;

            context.Result = new ApplicationErrorResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.ExceptionHandled = true;
        }

        public class ApplicationErrorResult : ObjectResult
        {
            public ApplicationErrorResult(object value) : base(value)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }



        public class ErrorResponse
        {
            public ErrorResponse(string msg)
            {
                Message = msg;
            }
            public string Message { get; set; }
            public object DeveloperMessage { get; set; }
        }
    }
}
