using AutoMapper;
using Happy_company.Data;
using Happy_company.Model.Domain;
using Happy_company.Model.DTO;
using Happy_company.Repositories.WarehouseRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Happy_company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public WarehousesController(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWarehouse([FromBody] WarehouseRequest request)
        {
            if (await _warehouseRepository.WarehouseExistsByName(request.Name))
            {
                return BadRequest(new { message = "Warehouse name must be unique." });
            }

            var warehouse = _mapper.Map<Warehouse>(request);
            warehouse.Id = Guid.NewGuid();

            await _warehouseRepository.CreateWarehouse(warehouse);

            var warehouseDto = _mapper.Map<WarehouseDTO>(warehouse);
            return CreatedAtAction(nameof(GetWarehouseById), new { id = warehouse.Id }, new
            {
                warehouse = warehouseDto,
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouseById(Guid id)
        {
            var warehouse = await _warehouseRepository.GetWarehouseById(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            var warehouseDto = _mapper.Map<WarehouseDTO>(warehouse);
            return Ok(warehouseDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWarehouses(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var totalWarehouses = await _warehouseRepository.GetTotalWarehouses();
            var totalPages = (int)Math.Ceiling(totalWarehouses / (double)pageSize);

            var warehouses = await _warehouseRepository.GetAllWarehouses(pageNumber, pageSize);
            var warehouseDtos = _mapper.Map<List<WarehouseDTO>>(warehouses);

            var response = new
            {
                TotalWarehouses = totalWarehouses,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Warehouses = warehouseDtos
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouse(Guid id, [FromBody] WarehouseRequest request)
        {
            var warehouse = await _warehouseRepository.GetWarehouseById(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            if (await _warehouseRepository.WarehouseExistsByName(request.Name, id))
            {
                return BadRequest(new { message = "Warehouse name must be unique." });
            }

            _mapper.Map(request, warehouse);

            await _warehouseRepository.UpdateWarehouse(warehouse);

            var warehouseDto = _mapper.Map<WarehouseDTO>(warehouse);
            return Ok(warehouseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(Guid id)
        {
            var warehouse = await _warehouseRepository.GetWarehouseById(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            await _warehouseRepository.DeleteWarehouse(warehouse);

            var warehouseDto = _mapper.Map<WarehouseDTO>(warehouse);

            return Ok(new { message = "Warehouse deleted successfully.", warehouseDto });
        }
    }
}

