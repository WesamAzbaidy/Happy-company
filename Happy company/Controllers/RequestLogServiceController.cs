using Happy_company.Data;
using Happy_company.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Happy_company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestLogServiceController : ControllerBase
    {
        private readonly DataContext context;

        public RequestLogServiceController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<List<RequestLog>> GetLogs()
        {
            return await context.RequestLogs
                .Select(log => new RequestLog
                {
                    Id = log.Id,
                    Method = log.Method,
                    Path = log.Path,
                    QueryString = log.QueryString,
                    Timestamp = log.Timestamp
                })
                .ToListAsync();
        }
    }
}
