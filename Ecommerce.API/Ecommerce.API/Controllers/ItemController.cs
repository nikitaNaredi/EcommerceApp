using Ecommerce.API.Models;
using Ecommerce.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    /*[ApiExplorerSettings(GroupName = "ItemsLoad")]*/
    public class ItemController: ControllerBase
    {
        private IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository){
            _itemRepository = itemRepository;
        }

        [HttpGet]
        [Route("items")]
        public Task<ActionResult<IEnumerable<Item>>> GetItemsAsync()
        {
            return _itemRepository.GetItemsAsync();
        }

        [HttpGet]
        [Route("items/{id}")]
        public Task<ActionResult<Item>> GetItemByIdAsync(long id)
        {
            return _itemRepository.GetItemByIdAsync(id);
        }
    }
}
