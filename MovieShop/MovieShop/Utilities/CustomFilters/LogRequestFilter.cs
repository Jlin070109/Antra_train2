using Microsoft.AspNetCore.Mvc.Filters;

namespace Utilities.CustomFilters
{
    public class LogRequestFilter: ActionFilterAttribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            //_logger.LogInformation($"Request to {controllerName}/{actionName} - {DateTime.Now}");
            await next();
        }
        public async Task OnActionExecutedAsync(ActionExecutedContext context)
        {
            // Optional: Perform actions after the method executes (e.g., log response)
        }
    }
}
