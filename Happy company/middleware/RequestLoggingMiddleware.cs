using Happy_company.Data;
using Happy_company.Model.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, DataContext dbContext)
    {
        var requestLog = new RequestLog
        {
            Id = Guid.NewGuid(),
            Method = context.Request.Method,
            Path = context.Request.Path,
            QueryString = context.Request.QueryString.ToString(),
            Timestamp = DateTime.UtcNow
        };

        dbContext.RequestLogs.Add(requestLog);
        await dbContext.SaveChangesAsync();

        await _next(context);
    }
}
