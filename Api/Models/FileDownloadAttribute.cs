using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Models;

public class FileDownloadAttribute : ActionFilterAttribute
{
    public string FileName { get; set; } = null!;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        context.HttpContext.Response.Headers.Add("Content-Disposition", $"attachment; filename={FileName}");
    }
}