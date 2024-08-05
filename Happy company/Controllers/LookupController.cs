using AutoMapper;
using Happy_company.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy_company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly DataContext _dbContext;
        private readonly IMapper mapper;

        public LookupController(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetAllLookupData()
        {

            var roles = await _dbContext.Roles.ToListAsync();
            var countries = await _dbContext.Countries.ToListAsync();


            var response = new
            {
                Roles = roles,
                Countries = countries
            };

            return Ok(response);
        }
    }
}
