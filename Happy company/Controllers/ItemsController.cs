using AutoMapper;
using Happy_company.Data;
using Happy_company.Model;
using Happy_company.Model.Domain;
using Happy_company.Model.DTO;
using Happy_company.Repositories.ItemsRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Happy_company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItemsRepository _itemsRepository;

        public ItemsController(IMapper mapper, IItemsRepository itemsRepository)
        {
            _mapper = mapper;
            _itemsRepository = itemsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] ItemRequest request)
        {
            if (await _itemsRepository.ExistsByNameAsync(request.Name))
            {
                return BadRequest(new { message = "Item name must be unique." });
            }

            var item = _mapper.Map<Items>(request);
            item.Id = Guid.NewGuid();

            var newItem = await _itemsRepository.CreateAsync(item);

            var itemDto = _mapper.Map<ItemsDTO>(newItem);
            return CreatedAtAction(nameof(GetItemById), new { id = itemDto.Id }, itemDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(Guid id)
        {
            var item = await _itemsRepository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var itemDto = _mapper.Map<ItemsDTO>(item);
            return Ok(itemDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemsRepository.GetAllAsync();
            return Ok(_mapper.Map<List<ItemsDTO>>(items));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, [FromBody] ItemRequest request)
        {
            var existingItem = await _itemsRepository.GetByIdAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            if (await _itemsRepository.ExistsByNameAsync(request.Name, id))
            {
                return BadRequest(new { message = "Item name must be unique." });
            }

            _mapper.Map(request, existingItem);

            await _itemsRepository.UpdateAsync(existingItem);

            var itemDTO = _mapper.Map<ItemsDTO>(existingItem);
            return Ok(itemDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = await _itemsRepository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            await _itemsRepository.DeleteAsync(item);

            var itemDTO = _mapper.Map<ItemsDTO>(item);
            return Ok(new { message = "Item deleted successfully.", itemDTO });
        }
        [HttpGet("highlowitems")]
        public async Task<IActionResult> HighLowItems()
        {
            var items = await _itemsRepository.GethighLowItemsAsync();
            var highQtyItem = items.HighQtyItem;
            var lowQtyItem = items.LowQtyItem;

            if (highQtyItem == null && lowQtyItem == null)
            {
                return NotFound("No items found.");
            }

            var highQtyItemDTO = _mapper.Map<ItemsDTO>(highQtyItem);
            var lowQtyItemDTO = _mapper.Map<ItemsDTO>(lowQtyItem);

            return Ok(new
            {
                message = "High and low quantity items retrieved successfully.",
                highQtyItem = highQtyItemDTO,
                lowQtyItem = lowQtyItemDTO
            });
        }

    }
}
