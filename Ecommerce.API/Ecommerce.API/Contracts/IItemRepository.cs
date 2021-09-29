using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Repositories
{
    public interface IItemRepository
    {
        Task<ActionResult<IEnumerable<Item>>> GetItemsAsync();
        Task<ActionResult<Item>> GetItemByIdAsync(long Id);
    }
}
